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
    public FloatObject heartContainer;
    public FloatObject playerCurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        InitializeHearts();
    }

    private void InitializeHearts()
    {
        for (int i = 0; i < heartContainer.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }
    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.runTimeValue / 2; // for partial hearts
        for (int i = 0; i < heartContainer.runTimeValue; i++)
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
