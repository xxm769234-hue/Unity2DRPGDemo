using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int currentHealth;//当前生命值
    public int MaxHealth;//最大生命值
    public int ExpReward = 3;
    public delegate void MonsterDefeated(int Exp);
    public static event MonsterDefeated OnMonsterDefeated;//创建静态事件，方便监听

    private void Start()
    {
        currentHealth = MaxHealth;
    }

    public void ChangeHealth(int amount)//公用改变生命值函数，后续敌人玩家生命值改变都用这个函数
    {
        currentHealth += amount;
       if(currentHealth>MaxHealth)
        {
            currentHealth = MaxHealth;
        }
        else if (currentHealth <= 0)
        {
            OnMonsterDefeated(ExpReward);
           Destroy(gameObject);
        }
        
    }
}
