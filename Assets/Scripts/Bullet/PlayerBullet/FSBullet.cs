using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSBullet : MonoBehaviour
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
    private FSBulletPool parentPool;


    private void Awake()
    {
        bulletCurrentSpeed = bulletData.FSBulletSpeed;
        bulletCurrentDamage = bulletData.playerBulletDamage;
        bulletCurrentDamageMultipler = bulletData.FSBulletDamageMultipler;
        bulletCurrentPenetrationCount = bulletData.FSBulletPenetrationCount;
    }

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        parentPool = FindObjectOfType<FSBulletPool>();
        EventHandler.CallPlaySoundEvent(SoundName.Shot1);
    }

    void Update()
    {
        Move();
        Existence();
    }

    void Move()
    {
        rb2D.velocity = transform.up * bulletCurrentSpeed;
    }

    void Existence()
    {
        newTime += Time.deltaTime;
        float bulletET = bulletData.linerBulletExistenceTime * bulletData.FSbulletETMultipler;
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
}
