using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    public float followRadius = 6f;
    public float smoothTime = 0.5f;
    private Vector2 currentVelocity;

    private void Start()
    {
        player = FindObjectOfType<PlayerState>().transform;
    }

    void Update()
    {
        if (player != null)
        {
            // 计算敌人和玩家之间的距离
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // 如果距离大于半径+允许的误差，向玩家移动
            if (distanceToPlayer > followRadius + 0.1f)
            {
                // 计算朝向玩家的方向
                Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;

                // 使用 SmoothDamp 平滑地移动敌人
                Vector2 targetPosition = (Vector2)player.position - direction * followRadius;
                transform.position = Vector2.SmoothDamp((Vector2)transform.position, targetPosition, ref currentVelocity, smoothTime);
            }
            // 如果距离小于半径-允许的误差，向相反方向移动
            else if (distanceToPlayer < followRadius - 0.1f)
            {
                // 计算朝向相反方向的方向
                Vector2 direction = ((Vector2)transform.position - (Vector2)player.position).normalized;

                // 使用 SmoothDamp 平滑地移动敌人
                Vector2 targetPosition = (Vector2)player.position + direction * followRadius;
                transform.position = Vector2.SmoothDamp((Vector2)transform.position, targetPosition, ref currentVelocity, smoothTime);
            }

            // 在这里可以添加其他处理，比如播放动画等
        }
    }
}
