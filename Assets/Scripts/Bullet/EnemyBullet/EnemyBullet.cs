using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletExistenceTime;
    [SerializeField] [ReadOnly]
    private float newTime;
    public int damage;

    private EnemyBulletPool parentPool;

    private void Start()
    {
        parentPool = FindObjectOfType<EnemyBulletPool>();
    }

    private void Update()
    {
        newTime += Time.deltaTime;
        if (newTime >= bulletExistenceTime)
        {
            newTime = 0f;
            parentPool.ReleaseExplosion(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //伤害传输
            PlayerState player = collision.gameObject.GetComponent<PlayerState>();
            player.TakeDamage(damage);
            //回收
            parentPool.ReleaseExplosion(this);
        }
    }

}
