using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;


public class player_movement : MonoBehaviour
{
    
    public Rigidbody2D rb;//创建刚体对象
    public Animator anim;//创建动画对象
    public int facingdirection = 1;//对象面向方向向量
    private bool isKnockedBack;
    public Player_Combat player_combat;
    
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Slash"))//检测到按下键盘Slash则调用下面的Attack函数
        {
            player_combat.Attack();
        }
        
        
        
    }
    void FixedUpdate()
    {
        if (isKnockedBack == false)
        {
            float horizontal = Input.GetAxis("Horizontal");//检测键盘输入移动方向，查询unity输入管理器中的变量，下同
            float vertical = Input.GetAxis("Vertical");
            if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }
            anim.SetFloat("horizontal", Mathf.Abs(horizontal));//动画读取移动指令
            anim.SetFloat("vertical", Mathf.Abs(vertical));
            rb.velocity = new Vector2(horizontal, vertical) * StatsManager.Instance.speed;//执行移动
        }
    }
    void Flip()
    {
        facingdirection *= -1;//对对象面向方向向量执行更改，保持变量状态
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);//目标对象的局部缩放分量必须整体修改，不可单个修改
    }
    public void Knockback(Transform enemy,float force,float Stuntime)//实现玩家被击退的效果，设置为公共函数方便后续敌人也可以调用此方法，避免重复编程,传入了一个击退力（决定击退多远），一个击退时间（决定控制时间）
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;//数据归一化
        rb.velocity = direction * force;
        StartCoroutine(KonockCounter(Stuntime));//启动协程
    }
    IEnumerator KonockCounter(float Stuntime)//枚举器
    {
        yield return new WaitForSeconds(Stuntime);//返回等待秒数，此行令此处等待一秒后执行下一行代码
        rb.velocity = Vector2.zero;
        isKnockedBack = false;
    }
}
