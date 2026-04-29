using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeSkillManager : MonoBehaviour
{
    public Heal Player_Heal;
    private void OnEnable()
    {
        SkillSlots.OnAbilityPointSpent += HandlePointsSpent;//监听到OnAbilityPointSpent事件发生时，调用HandlePointsSpent方法
    }
    private void OnDisable()
    {
        SkillSlots.OnAbilityPointSpent -= HandlePointsSpent;
    }
    private void HandlePointsSpent(SkillSlots slot)
    {
        
        string skillName = slot.Skillso.SkillName;
        switch(skillName)
        {
            case "MaxHealthBoost":
                StatsManager.Instance.UpdateMaxHealth(1);
                break;
            case "DamageBoost":
                StatsManager.Instance.UpdateDamage(1);
                break;
            case "StuntimeUp":
                StatsManager.Instance.UpdateStunTime(0.1f);
                break;
            case "Heal":
                Player_Heal.enabled = true;
                break;
            default:
                Debug.LogWarning("Undefined" + skillName);
                break;
                
        }
    }
}
