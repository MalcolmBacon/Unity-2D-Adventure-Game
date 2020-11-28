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
        InitializeHearts();
    }

    private void InitializeHearts()
    {
        //Need to change so that only adding a new game object instead of setting active in case player starting health is greater than number of heart containers
        for (int i = 0; i < playerCurrentHealth.initialValue / 2; i++)
        {
            hearts[i].gameObject.SetActive(true);
            if (i < 3)
            {
                hearts[i].sprite = fullHeart;
            }
            else 
            {
                hearts[i].sprite = armourFullHeart;
            }
        }
    }
    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.runTimeValue / 2; // for partial hearts
        for (int i = 0; i < playerCurrentHealth.runTimeValue / 2; i++)
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
                    hearts[i].sprite = fullHeart;
                }
                else if (i >= tempHealth)
                {
                    //Empty heart
                    hearts[i].sprite = emptyHeart;
                }
                else
                {
                    //Half heart
                    hearts[i].sprite = halfHeart;
                }
            }
        }
    }
}
