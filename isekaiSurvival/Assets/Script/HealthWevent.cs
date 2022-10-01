using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthWevent : MonoBehaviour
{
    [SerializeField] private int _maxHp = 100;

    private int _hp;

    public int MaxHp => _maxHp; //get maxhp value from inspector

    public int Hp
    {
        get => _hp;
        private set
        {
            var isDamage = value < _hp;
            _hp = Mathf.Clamp(value, 0, _maxHp);

            if (isDamage)
            {
                Damaged?.Invoke(_hp);
            }
            else
            {
                Healed?.Invoke(_hp);
            }
            if (_hp <= 0)
            {
                Died?.Invoke();
            }
        }
    }
    //-- Unity Event for add events to unity inspector --//
    public UnityEvent<int> Healed;
    public UnityEvent<int> Damaged;
    public UnityEvent Died;

    //----------------------------------//
    private void Awake()
    {
        _hp = _maxHp; //max hp become object's hp when invoke this class 
    }

    public void Damage(int amount) => Hp -= amount;

    public void Heal(int amount) => Hp += amount;

    public void HealFull() => Hp = _maxHp;

    public void Kill() => Hp = 0;

    public void Adjust(int value) => Hp = value;
}
