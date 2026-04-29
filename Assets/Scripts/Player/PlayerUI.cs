using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject[] StatsSlots;
    public CanvasGroup StatsCanvas;
    private bool isStatsOpened;
    private void Start()
    {
        UpdateAllStats();
        isStatsOpened = false;
    }
    private void Update()
    {
        if(Input.GetButtonDown("OpenStats"))
        {
            if (isStatsOpened == true)
            {
                Time.timeScale = 1;
                
                StatsCanvas.alpha = 0;//设置画布alpha值为0，令其变透明（隐藏）
                isStatsOpened = false;
            }
            else
            {
                Time.timeScale = 0;//静止物理运算，即动画，移动等全静止
                StatsCanvas.alpha = 1;
                isStatsOpened = true;
            }
        }
    }
    public void UpdateDamage()
    {
        StatsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage:" + StatsManager.Instance.Damage;//更新对象数组中的第一个对象中子对象文本框的文字内容
    }
    public void UpdateSpeed()
    {
        StatsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed:" + StatsManager.Instance.speed;
    }
    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
    }
}
