using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
   public int Damage = 1;
    public Transform attackpoint;//transform引用
    public float weaponRange;
    public LayerMask PlayerLayer;//层级遮罩
    public float knockbackForce;
    public float Stuntime;
   
    public void Attack()//在动画帧对应事件方法调用中被调用
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackpoint.position, weaponRange,PlayerLayer); //以attackpoint点为中心创建一个半径为weaponrange的圆，并检测其中的碰撞体对象，存入数组中
        if(hits.Length>0)
        {
            hits[0].GetComponent<Player_Health>().ChangeHealth(-Damage);//对上面的数组中的第一个对象执行调用Changehealth方法
            hits[0].GetComponent<player_movement>().Knockback(transform,knockbackForce,Stuntime);//攻击时调用击退方法
        }
    }
}
