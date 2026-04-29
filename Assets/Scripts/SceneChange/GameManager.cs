using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("persistent object")]
    public GameObject[] PersisitentObjects;
    private void Awake()
    {
     if(Instance != null)//如果存在多个对象就销毁只剩下一个作为单例
        {
            CleanupAndDestory();
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);//进入新场景时不销毁游戏对象
            MarkPersistentObject();
        }
    }

    private void CleanupAndDestory()
    {
        foreach (GameObject obj in PersisitentObjects)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }

    private void MarkPersistentObject()
    {
        foreach(GameObject obj in PersisitentObjects)
        {
            if (obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }
}
