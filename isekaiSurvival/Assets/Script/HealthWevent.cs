using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthWevent : MonoBehaviour
{
    [SerializeField] private int maxHp;

    private int hp;
    #region PUBLIC_VARIABLE
    public int MaxHp => maxHp; //get maxhp value from inspector

    public int Hp // set conditions to hp
    {
        get => hp;
        private set
        {
            var isDamage = value < hp;
            hp = Mathf.Clamp(value, 0, maxHp);

            if (isDamage)
            {
                Damaged?.Invoke(hp);
            }
            else
            {
                Healed?.Invoke(hp);
            }
            if (hp <= 0)
            {
                Died?.Invoke();
            }
        }
    }
    #endregion
    //-- Unity Event for add events to unity inspector --//
    public UnityEvent<int> Healed;
    public UnityEvent<int> Damaged;
    public UnityEvent Died;

    //----------------------------------//
    #region HP_FUNCTION
    private void Awake()
    {
        hp = maxHp; //max hp become object's hp when invoke this class 
    }

    // funtions about hp changing

    public void Damage(int amount) => Hp -= amount;

    public void Heal(int amount) => Hp += amount;

    public void HealFull() => Hp = maxHp;

    public void Kill() => Hp = 0;

    public void Adjust(int value) => Hp = value;
    #endregion
}
