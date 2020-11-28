using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public Sprite armourFullHeart;
    public Sprite armourHalfHeart;
    public Sprite armourEmptyHeart;
   // public FloatObject heartContainer;
    public FloatObject playerCurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.runTimeValue / 2; // for partial hearts
        for (int i = 0; i < playerCurrentHealth.maxRunTimeValue / 2; i++)
        {
            if (i >= 3) //Armour hearts
            {
                if (i <= tempHealth - 1)
                {
                    //Full heart
                    hearts[i].gameObject.SetActive(true);
                    hearts[i].sprite = armourFullHeart;
                }
                else if (i >= tempHealth)
                {
                    //Empty heart
                    hearts[i].gameObject.SetActive(true);
                    hearts[i].sprite = armourEmptyHeart;
                }
                else
                {
                    //Half heart
                    hearts[i].gameObject.SetActive(true);
                    hearts[i].sprite = armourHalfHeart;
                }
            }
            else
            {
                if (i <= tempHealth - 1)
                {
                    //Full heart
                    hearts[i].gameObject.SetActive(true);
                    hearts[i].sprite = fullHeart;
                }
                else if (i >= tempHealth)
                {
                    //Empty heart
                    hearts[i].gameObject.SetActive(true);
                    hearts[i].sprite = emptyHeart;
                }
                else
                {
                    //Half heart
                    hearts[i].gameObject.SetActive(true);
                    hearts[i].sprite = halfHeart;
                }
            }
        }
    }
}
