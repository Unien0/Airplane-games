using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBullet : MonoBehaviour
{
    public PlayerBullet_SO bulletData;
    #region 基础数据
    public float linerBulletSpeed
    {
        get { if (bulletData != null) return bulletData.linerBulletSpeed; else return 0; }
    }
    public int playerBulletDamage
    {
        get { if (bulletData != null) return bulletData.playerBulletDamage; else return 0; }
    }
    public float linerBulletDamageMultipler
    {
        get { if (bulletData != null) return bulletData.linerBulletDamageMultipler; else return 0; }
    }
    public float linerBulletExistenceTime
    {
        get { if (bulletData != null) return bulletData.linerBulletExistenceTime; else return 3; }
    }
    public int linerBulletPenetrationCount//穿透次数
    {
        get { if (bulletData != null) return bulletData.linerBulletPenetrationCount; else return 1; }
    }
    #endregion

    //当前数据，只读
    [SerializeField][ReadOnly]
    private float linerBulletCurrentSpeed=1;
    [SerializeField][ReadOnly]
    private int playerBulletCurrentDamage = 1;
    [SerializeField][ReadOnly]
    private float linerBulletCurrentDamage=1;
    [SerializeField][ReadOnly]
    private int linerBulletCurrentPenetrationCount=1;
    [SerializeField][ReadOnly]
    private float newTime;
    //[SerializeField][ReadOnly]
    //private bool canRelease;

    //组件获取
    private Rigidbody2D rb2D;
    private Collider2D col2d;
    private BulletPool parentPool;

    private void Awake()
    {
        linerBulletCurrentSpeed = linerBulletSpeed;
        playerBulletCurrentDamage = playerBulletDamage;
        linerBulletCurrentDamage = linerBulletDamageMultipler;
        linerBulletCurrentPenetrationCount = linerBulletPenetrationCount;
    }

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        parentPool = FindObjectOfType<BulletPool>();
    }

    void Update()
    {
        Move();
        Existence();
    }

    void Move()
    {
        rb2D.velocity = transform.up * linerBulletCurrentSpeed;
    }

    void Existence()
    {
        newTime += Time.deltaTime;
        if (newTime >= linerBulletExistenceTime)
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
        int damage = (int)(playerBulletCurrentDamage * linerBulletCurrentDamage);
        Debug.Log(damage);
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
            linerBulletCurrentPenetrationCount--;
            if (linerBulletCurrentPenetrationCount <= 0)
            {
                parentPool.ReleaseExplosion(this);
            }
        }
    }
}
