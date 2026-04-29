using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    private float CoolDownTimer;
    public Transform attackpoint;
    public float weaponRange;
    public LayerMask EnemyLayer;
    
    private void Update()
    {
        CoolDownTimer -= Time.deltaTime;
    }
    public void Attack()//冷却时间为零的话播放动画
    {
        
        if (CoolDownTimer <= 0)
        {
            CoolDownTimer = StatsManager.Instance.CoolDown;

            anim.SetBool("isAttacking", true);
           
        }
    }
    public void dealDamage()//采用动画关键帧事件调用
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackpoint.position, weaponRange, EnemyLayer); //以attackpoint点为中心创建一个半径为weaponrange的圆，并检测其中的碰撞体对象，存入数组中，只有Layer层级遮罩为EnemyLayer的为有效元素，另一个遮罩同理
        if (hits.Length > 0)
        {
            hits[0].GetComponent<Enemy_Health>().ChangeHealth(-StatsManager.Instance.Damage);//对上面的数组中的第一个对象执行调用Changehealth方法
            hits[0].GetComponent<Enemy_Knock>().KnockBack(transform, StatsManager.Instance.knockbackForce, StatsManager.Instance.Knocktime, StatsManager.Instance.Stuntime);//攻击时调用击退方法
        }
    }
    public void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
    }
}
