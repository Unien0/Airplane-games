using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //敌人状态
    public EnemyData_SO enemyData;


    //敌人基本属性
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int currentDamage;

    public bool isDead;

    Transform player;

    Animator anim;

    void Awake()
    {
        //Assign the vaiables
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;

        anim = GetComponent<Animator>();
    }
    void Start()
    {
        player = FindObjectOfType<PlayerState>().transform;
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 敌方个体受伤
    /// </summary>
    /// <param name="dmg"></param>
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            //改变个体Layer至敌人尸体栏
            //gameObject.layer = 9;
            isDead = true;
            //anim.SetBool("Dead", true);
            //Kill();
        }
    }

    /// <summary>
    /// 敌人个体死亡
    /// </summary>
    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
