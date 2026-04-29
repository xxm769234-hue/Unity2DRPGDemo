using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaManger : MonoBehaviour
{
    
    public int maxMana = 5;
    public Slider ManaSlider;
    public TMP_Text Mana;
    public int CurrentMana;
    public Heal heal;

    private void Start()//¸üÐÂUIÏÔÊ¾
    {
        CurrentMana = maxMana;
        UpdateUI();
    }
    private void OnEnable()
    {
        Heal.ManaSpentToHeal += manaSpent;
    }
    private void OnDisable()
    {
        Heal.ManaSpentToHeal -= manaSpent;
    }
    public void manaSpent(int amount)
    {
        if (CurrentMana > 0)
        {
            CurrentMana -= amount;
            UpdateUI();
            heal.heal();
        }
    }

    public void UpdateUI()
    {
        ManaSlider.maxValue = maxMana;
        ManaSlider.value = CurrentMana;
        Mana.text = CurrentMana+"/"+maxMana;
    }
}
