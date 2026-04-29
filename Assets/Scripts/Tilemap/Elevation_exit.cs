using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevation_exit : MonoBehaviour
{
    public Collider2D[] mountainColleders;//定义2d碰撞体数组，批量管理碰撞体
    public Collider2D[] boundaryColleders;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//确保只有当接触碰撞体的sprite的tag为Player时才会触发以下效果
        {
            foreach (Collider2D mountain in mountainColleders)//遍历循环，遍历2d碰撞体数组中的每一个元素
            {
                mountain.enabled = true;//效果为开启数组内碰撞体效果
            }
            foreach (Collider2D boundary in boundaryColleders)//遍历循环，遍历2d碰撞体数组中的每一个元素
            {
                boundary.enabled = false;//效果为关闭数组内碰撞体效果
            }
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;//查找角色（精灵对象），并将其图层设置为5(原值）
        }
    }
}
