using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifepointManager : MonoBehaviour
{
    //[SerializeField] private GameObject player;

    [SerializeField] private HealthWevent playerHealth; 
    

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        SetLifepoints();
    }

    private void SetLifepoints()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth.Hp)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < playerHealth.MaxHp)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
