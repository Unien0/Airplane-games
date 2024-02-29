using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMissile : MonoBehaviour
{
    [Header("靠近攻击")]
    public PlayerBullet_SO bulletData;
    public PlayerData_SO playerData;

    [SerializeField]
    [ReadOnly]
    private float time;
    private Transform player;
    private float bulletCD;
    private float trackingRange = 10f; // 定义追踪范围
    private bool hasFiredBullet = false; // 添加标记

    private void Start()
    {
        player = GetComponent<Transform>();
        bulletCD = bulletData.TMbulletCDMultipler * bulletData.linerBulletCoolDownTime;
    }

    void Update()
    {
        if (!playerData.isDead)
        {
            // 检测最近的敌人
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, trackingRange);
            Transform closestEnemy = null;
            float closestDistanceSqr = Mathf.Infinity;
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Vector3 directionToEnemy = collider.transform.position - transform.position;
                    float dSqrToEnemy = directionToEnemy.sqrMagnitude;
                    if (dSqrToEnemy < closestDistanceSqr)
                    {
                        closestDistanceSqr = dSqrToEnemy;
                        closestEnemy = collider.transform;
                    }
                }
            }

            if (closestEnemy != null && !hasFiredBullet) // 添加条件判断是否已经生成了子弹
            {
                // 调整子弹的方向
                Vector3 direction = closestEnemy.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle); // 使用Euler角度来设置旋转
                transform.Rotate(Vector3.forward * 90); // 如果需要微调方向，可以额外旋转子弹

                // 发射子弹
                if (time >= bulletCD)
                {
                    FindObjectOfType<TMBulletPool>().GetExplosion(transform.position, transform.rotation);
                    EventHandler.CallPlaySoundEvent(SoundName.Shot1);
                    time -= bulletCD;
                    hasFiredBullet = true; // 设置标记为已经生成了子弹
                }
            }
            else if (closestEnemy == null) // 添加条件重置标记
            {
                hasFiredBullet = false;
            }

            time += Time.deltaTime;
        }
    }
}

