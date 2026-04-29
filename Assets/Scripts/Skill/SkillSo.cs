using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="NewSkill",menuName="SkillTree/Skill")]
public class SkillSo : ScriptableObject//可脚本化对象
{
    public string SkillName;
    public int maxLevel;
    public Sprite SkillIcon;
}
