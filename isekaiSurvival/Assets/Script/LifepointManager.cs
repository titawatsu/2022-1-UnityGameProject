using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifepointManager : MonoBehaviour
{

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
        for (int num = 0; num < hearts.Length; num++) // for make heart image display display equal player's hp
        {
            if (num < playerHealth.Hp) hearts[num].sprite = fullHeart;

            else hearts[num].sprite = emptyHeart;

            if (num < playerHealth.MaxHp) hearts[num].enabled = true;

            else hearts[num].enabled = false;

        }
    }

}
