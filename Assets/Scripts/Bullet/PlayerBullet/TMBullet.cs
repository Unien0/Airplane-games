using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMBullet : MonoBehaviour
{
    public PlayerBullet_SO bulletData;
    [SerializeField]
    [ReadOnly]
    private float bulletCurrentSpeed = 1;
    [SerializeField]
    [ReadOnly]
    private int bulletCurrentDamage = 1;
    [SerializeField]
    [ReadOnly]
    private float bulletCurrentDamageMultipler = 1;
    [SerializeField]
    [ReadOnly]
    private int bulletCurrentPenetrationCount = 1;
    [SerializeField]
    [ReadOnly]
    private float newTime;
    //[SerializeField][ReadOnly]
    //private bool canRelease;

    private Rigidbody2D rb2D;
    private Collider2D col2d;
    private TMBulletPool parentPool;
    private Transform target; // 存储目标敌人的引用


    private void Awake()
    {
        bulletCurrentSpeed = bulletData.TMBulletSpeed;
        bulletCurrentDamage = bulletData.playerBulletDamage;
        bulletCurrentDamageMultipler = bulletData.TMBulletDamageMultipler;
        bulletCurrentPenetrationCount = bulletData.TMBulletPenetrationCount;
    }

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        parentPool = FindObjectOfType<TMBulletPool>();
        EventHandler.CallPlaySoundEvent(SoundName.Shot1);
        // 在开始时寻找最近的敌人作为目标
        FindClosestEnemy();
    }

    void Update()
    {
        Move();
        Existence();
    }

    void Move()
    {
        // 更新子弹的方向，朝向目标
        Vector2 direction = (target.position - transform.position).normalized;
        rb2D.velocity = direction * bulletCurrentSpeed;
    }

    void Existence()
    {
        newTime += Time.deltaTime;
        float bulletET = bulletData.linerBulletExistenceTime * bulletData.TMbulletETMultipler;
        if (newTime >= bulletET)
        {
            newTime = 0f;
            parentPool.ReleaseExplosion(this);
        }
    }

    void DealDamage(GameObject enemy)
    {
        //伤害传输
        //SpaceArtPublishState spaceArtPublishState = collision.gameObject.GetComponent<SpaceArtPublishState>();
        EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
        int damage = (int)(bulletCurrentDamage * bulletCurrentDamageMultipler);
        //Debug.Log(damage);
        //spaceArtPublishState.TakeDamage(damage);
        if (enemyStats != null)
        {
            enemyStats.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DealDamage(collision.gameObject);

            //回收
            bulletCurrentPenetrationCount--;
            if (bulletCurrentPenetrationCount <= 0)
            {
                parentPool.ReleaseExplosion(this);
            }
        }
    }
    // 寻找最近的敌人作为目标
    private void FindClosestEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, bulletData.trackingRange);
        float closestDistanceSqr = Mathf.Infinity;
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                float dSqrToEnemy = (collider.transform.position - transform.position).sqrMagnitude;
                if (dSqrToEnemy < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToEnemy;
                    target = collider.transform;
                }
            }
        }
    }
}
