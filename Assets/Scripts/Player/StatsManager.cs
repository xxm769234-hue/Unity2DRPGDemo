using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;//公共静态数值管理器引用，可以不用在其余脚本内创建StatsManager类引用对象，直接进行引用
    [Header("Combat")]
    public float CoolDown = 2;
    public float weaponRange;
    public int Damage = 2;
    public float Knocktime;
    public float Stuntime;
    public int knockbackForce;
    [Header("Movement")]
    public float speed = 5;
    [Header("Health")]
    public int currentHealth;//当前生命值
    public int MaxHealth;//最大生命值
    public int healnubmer;
    public TMP_Text healthText;
    public TMP_Text damageText;
    private void Awake()//程序开始时如不存在此静态引用则创建，有则删除原引用重新创建
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    public void UpdateMaxHealth(int amount)
    {
        MaxHealth += amount;
        currentHealth += amount;
        healthText.text = "HP:" + currentHealth + "/" + MaxHealth;
        
    }
    public void UpdateDamage(int amount)
    {
        Damage += amount;
        damageText.text = "Damage:"+ Damage;
    }
    public void UpdateStunTime(float amount)
    {
        Stuntime += amount;

    }

}
