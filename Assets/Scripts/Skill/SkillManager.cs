using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public SkillSlots[] skillSlots;
    public TMP_Text PointsText;
    public int aviliablePoints;
    private void Start()
    {
        foreach(SkillSlots slot in skillSlots)
        {
            slot.SkillButton.onClick.AddListener(()=>CheckSkillPoints(slot));//监听到按钮点击事件时调用方法，对指定的slot调用
        }
        UpgradePoints(0);
    }
    private void CheckSkillPoints(SkillSlots slot)
    {
        Debug.Log("1");
        if(aviliablePoints>0)
        {
            slot.UpGradeSkill();
        }
    }
    public void UpgradePoints(int amount)//控制技能点数的增减
    {
        aviliablePoints += amount;
        PointsText.text = "AbilityPoints:" + aviliablePoints;
    }

    private void OnEnable()//创建监听器,订阅方法
    {
        SkillSlots.OnAbilityPointSpent += HandleAbilityPointsSpent;
        SkillSlots.OnSkillMaxed += HandleSkillMaxed;
        EXPManager.OnLevelUp += UpgradePoints;
    }
    private void OnDisable()//销毁监听器，取消订阅方法
    {
        SkillSlots.OnAbilityPointSpent -= HandleAbilityPointsSpent;
        SkillSlots.OnSkillMaxed -= HandleSkillMaxed;
        EXPManager.OnLevelUp -= UpgradePoints;
    }
    private void HandleSkillMaxed(SkillSlots skillSlot)
    {
         foreach(SkillSlots slot in skillSlots)
        {
            if(!slot.isUnLocked && slot.CanUnlockSkill())
            {
                slot.Unlock();
            }
            
        }
    }
    private void HandleAbilityPointsSpent(SkillSlots skillSlots)
    {
        
        if (aviliablePoints > 0)
        {
            UpgradePoints(-1);
        }
    }
}
