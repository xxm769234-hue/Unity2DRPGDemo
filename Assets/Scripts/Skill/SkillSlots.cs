using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlots : MonoBehaviour
{
    public List<SkillSlots> SpecialSkill;
    public SkillSo Skillso;
    public Image SkillIcon;
    public int currentLevel;
    public bool isUnLocked;
    public TMP_Text SkillLevelText;
    public Button SkillButton;
    public static event Action<SkillSlots> OnAbilityPointSpent;
    public static event Action<SkillSlots> OnSkillMaxed;
    public void OnValidate()
    {
        if(Skillso !=null && SkillLevelText != null)
        {
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
         SkillIcon.sprite = Skillso.SkillIcon;
        if (isUnLocked)
        {
            SkillButton.interactable = true;
            SkillLevelText.text = currentLevel.ToString() + "/" + Skillso.maxLevel.ToString();
            SkillIcon.color = Color.white;
        }
        else
        {
            SkillButton.interactable = false;
            SkillLevelText.text = "Locked";
            SkillIcon.color = Color.grey;
        }
    }
    public void UpGradeSkill()
    {
        if (isUnLocked && currentLevel < Skillso.maxLevel)
        {
            currentLevel++;
            OnAbilityPointSpent?.Invoke(this);//´¥·¢ÊÂ¼þ¼àÌý
            if(currentLevel>=Skillso.maxLevel)
            {
                OnSkillMaxed?.Invoke(this);
            }
            UpdateUI();
        }
        
    }
    public bool CanUnlockSkill()
    {
        
        foreach(SkillSlots slot in SpecialSkill)
        {
            if(!slot.isUnLocked || slot.currentLevel<slot.Skillso.maxLevel)
            {
                
                return false;
                
            }
        }
        return true;
    }
    public void Unlock()
    {
        
        isUnLocked = true;
        UpdateUI();
    }
   
}
