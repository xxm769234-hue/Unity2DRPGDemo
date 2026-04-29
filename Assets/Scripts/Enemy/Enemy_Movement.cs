using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private EnemyState enemystate;
    private Rigidbody2D rb;
    private Transform Player;
    public float Speed = 3;
    //private bool isChasing;//是否处于追击状态
    private int facingdirection;
    private Animator anim;
    public float AttackRange =2;
    public float AttackCoolDown = 2;
    private float AttackCoolDowntimer;
    public float PlayerDetectRange = 5;
    public Transform detectpoint;
    public LayerMask PlayerLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//自动将对象的刚体填入对应对象的脚本所需刚体变量中
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);//初始化状态机状态
        facingdirection = (int)transform.localScale.x;
    }

    // Update is called once per frame
    void Update()//每帧检测并执行此方法下的逻辑
    {
        if (enemystate != EnemyState.Knockback)
        {
            CheckForPlayer();
            if (AttackCoolDowntimer > 0)
            {
                AttackCoolDowntimer -= Time.deltaTime;
            }
            if (enemystate == EnemyState.Chasing)
            {
                Chasing();
            }
            else if (enemystate == EnemyState.Attacking)//敌人进行攻击动作时需要停下来
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
    void Chasing()
    {
       
          if(Player.position.x>transform.position.x && facingdirection == -1 || Player.position.x < transform.position.x && facingdirection == 1)
          {
                Flip();
           }
         Vector2 Direction = (Player.position - transform.position).normalized;//玩家位置坐标减去当前敌人所在坐标，即移动方向，transform默认为调用当前对象的transform类对象,相减得到的结果进行归一化，方便控制移动快慢
         rb.velocity = Direction * Speed;
    }
    
    public void Flip()
    {
        facingdirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);//逻辑同玩家翻转逻辑
    }
    private void CheckForPlayer()//整体包含了设置对象检测框，判断不同状态以及各状态触发逻辑（攻击逻辑，追逐逻辑，待机逻辑）
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectpoint.position,PlayerDetectRange,PlayerLayer);//生成检测框，逻辑与敌人攻击（Enemy_Combat)中一致
        if(hits.Length>0)//判定数组内有元素，即玩家对象是否在检测框内
        {
            Player = hits[0].transform;
            if(Vector2.Distance(transform.position,Player.position)<=AttackRange && AttackCoolDowntimer <= 0)//如果攻击冷却计时器小于等于0且玩家对象在攻击范围内，则发动一次攻击并重置计时器
            {
                ChangeState(EnemyState.Attacking);
                AttackCoolDowntimer = AttackCoolDown;
            }
            else if(Vector2.Distance(transform.position, Player.position) > AttackRange && enemystate !=EnemyState.Attacking)//玩家对象不在攻击范围内则追逐
            {
                ChangeState(EnemyState.Chasing);
            }

        //ChangeState(EnemyState.Chasing);

        }
        else
        {
            rb.velocity = Vector2.zero;//将移动速度设置为零
            ChangeState(EnemyState.Idle);
        }
    }
   
    public void ChangeState(EnemyState newState)
    {
        
        //退出当前动画状态
        if (enemystate == EnemyState.Idle)
        {
            anim.SetBool("isIdle", false);
        }
        else if (enemystate == EnemyState.Chasing)
        {
            anim.SetBool("iswalking", false);
        }
        else if (enemystate == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", false);
        }
        //更新当前动画状态（反馈到unity参数中）
        enemystate = newState;
        //更新当前状态
        if (enemystate == EnemyState.Idle)
        {
            anim.SetBool("isIdle", true);
        }
        else if (enemystate == EnemyState.Chasing)
        {
            anim.SetBool("iswalking", true);
        }
        else if (enemystate == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", true);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectpoint.position, PlayerDetectRange);
    }
}

public enum EnemyState//创建状态机
{
    Idle,
    Chasing,
    Attacking,
    Knockback,
}