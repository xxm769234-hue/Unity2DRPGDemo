using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    
    public TMP_Text HealthText;
    public Animator HealthTextAnim;
    private void Start()//启动时执行此方法下的逻辑
    {
        HealthText.text = "HP:" + StatsManager.Instance.currentHealth + "/" + StatsManager.Instance.MaxHealth;//游戏开始时初始化生命值显示数据
    }
    public void ChangeHealth(int amount)//公用改变生命值函数，后续玩家生命值改变都用这个函数
    {
        StatsManager.Instance.currentHealth += amount;
        HealthTextAnim.Play("TextUpdate");
        HealthText.text = "HP:" + StatsManager.Instance.currentHealth + "/" + StatsManager.Instance.MaxHealth; //随生命值变化更新生命值显示数据
        if (StatsManager.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);//销毁玩家对象
        }
        else if(StatsManager.Instance.currentHealth>=StatsManager.Instance.MaxHealth)
        {
            StatsManager.Instance.currentHealth = StatsManager.Instance.MaxHealth;
            HealthText.text = "HP:" + StatsManager.Instance.currentHealth + "/" + StatsManager.Instance.MaxHealth; //随生命值变化更新生命值显示数据
        }
    }

}
  