using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBullet : MonoBehaviour
{
    public float speed;
    public int damage;
    private float newTime;
    public float existenceTime;


    private Rigidbody2D rb2D;
    private Collider2D col2d;
    private BulletPool parentPool;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        parentPool = FindObjectOfType<BulletPool>();
    }

    void Update()
    {
        Move();
        Existence();
    }

    void Move()
    {
        rb2D.velocity = transform.up * speed;
    }

    void Existence()
    {
        newTime += Time.deltaTime;
        if (newTime >= existenceTime)
        {
            newTime = 0f;
            parentPool.ReleaseExplosion(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //伤害传输


            //回收
            parentPool.ReleaseExplosion(this);
        }
    }
}
