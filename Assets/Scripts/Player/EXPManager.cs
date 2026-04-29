using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EXPManager : MonoBehaviour
{
    public int Level;
    public int CurrentEXP;
    public int expToLevel=10;
    public float expGrowthMultiplier=1.2f;
    public Slider EXPSlider;
    public TMP_Text currentLevel;
    public static event Action<int> OnLevelUp;
    private void Start()//更新UI显示
    {
        UpdateUI();
    }

   
    public void GainEXP(int amount)//监听到事件时调用此方法
    {
        CurrentEXP += amount;
        if(CurrentEXP>=expToLevel)
        {
            LevelUP();

        }
        UpdateUI();
    }
    private void OnEnable()//创建监听器
    {
        Enemy_Health.OnMonsterDefeated += GainEXP;
    }
    private void OnDisable()//关闭监听器
    {
        Enemy_Health.OnMonsterDefeated -= GainEXP;
    }
    private void LevelUP()
    {
        Level++;
        CurrentEXP -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expGrowthMultiplier);//每级经验提升百分之二十，mathf用来取整
        OnLevelUp?.Invoke(1); //可以在此处增加逻辑来决定升级获得的技能点数
    }
    public void UpdateUI()
    {
        EXPSlider.maxValue = expToLevel;
        EXPSlider.value = CurrentEXP;
        currentLevel.text = "Level:" + Level;
    }
}
