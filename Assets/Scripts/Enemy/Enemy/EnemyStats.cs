using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //敌人状态
    public EnemyData_SO enemyData;
    public int maxHealth
    {
        get { if (enemyData != null) return enemyData.maxHealth; else return 0; }
    }

    //敌人基本属性
    public string enemyID;

    [HideInInspector]
    public float currentMoveSpeed;
    [SerializeField]
    [ReadOnly]
    private int currentHealth = 1;
    [HideInInspector]
    public int currentDamage;

    public bool isDead;

    Transform player;
    EnemyPool parentPool;
    Animator anim;

    void Awake()
    {
        //Assign the vaiables
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
    }

    void Start()
    {
        player = FindObjectOfType<PlayerState>().transform;
        parentPool = FindObjectOfType<EnemyPool>();
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
            gameObject.layer = 9;
            isDead = true;
            //anim.SetBool("Dead", true);
            Kill();
        }
    }

    /// <summary>
    /// 敌人个体死亡
    /// </summary>
    public void Kill()
    {
        //在对象池中调用敌人爆炸动画
        FindObjectOfType<ExplosionEffectPool>().GetExplosion(this.transform.position);
        EventHandler.CallPlaySoundEvent(SoundName.EnemyDie1);
        //死亡时候调用敌人生成器里的数量检测
        EnemySpawner enemyKill = FindObjectOfType<EnemySpawner>();
        enemyKill.OnEnemyKilled(enemyID);
        //回收敌人至对象池
        parentPool.ReleaseExplosion(this);
    }
    //回收后初始化敌人
    private void OnDisable()
    {
        currentHealth = maxHealth;
        isDead = false;
        gameObject.layer = 7;
    }

}
