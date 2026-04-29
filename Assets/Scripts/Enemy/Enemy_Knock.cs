using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Knock : MonoBehaviour
{
    private Rigidbody2D rb;
    private Enemy_Movement enemy_movement;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy_movement = GetComponent<Enemy_Movement>();
    }
    public void KnockBack(Transform playerTransform,int knockbackForce,float Knocktime,float Stuntime)
    {
        enemy_movement.ChangeState(EnemyState.Knockback);
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.velocity = direction * knockbackForce;
        StartCoroutine(KonockCounter(Knocktime,Stuntime));//启动协程
    }
    IEnumerator KonockCounter(float Knocktime,float Stuntime)//枚举器
    {
        yield return new WaitForSeconds(Knocktime);//返回等待秒数，此行令此处等待Stuntime秒后执行下一行代码
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(Stuntime);
        enemy_movement.ChangeState(EnemyState.Chasing);
        
    }
}
