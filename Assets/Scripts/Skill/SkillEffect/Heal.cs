using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Player_Health player_Health;
    public static event Action<int> ManaSpentToHeal;

    void Update()
    {
        if (Input.GetButtonDown("Heal"))
        {

            ManaSpentToHeal?.Invoke(1);
            
        }
    }
    public void heal()
    {
         player_Health.ChangeHealth(StatsManager.Instance.healnubmer);
    }
}
