using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        //public List<GameObject> enemyPrefabs;
        //public List<string> enemyName;
        //public List<int> enemyCount;
        [Header("敌人类型")]
        public List<EnemyGroup> enemyGroups;
        [Tooltip("当前波额定值，不能为0")] public int waveQuota;//当前波额定值
        [Tooltip("生成间隔")] public float spawnInterval;//生成间隔
        [Tooltip("第几波，默认为0")] public int spawnCount;//第几波

    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        [Tooltip("敌人数")] public int enemyCount;//敌人数
        [Tooltip("生成数，默认为0")] public int spawnCount;//生成数
        public GameObject enemyPrefab;

    }
    [Header("波次")]
    public List<Wave> waves;

    [Header("参数")]
    [Tooltip("当前波次")] public int currentWaveCount;//当前波次
    float spawnTimer;
    [Tooltip("波次间隔")] public float waveInterval;
    [Tooltip("敌人存活数")]public int enemiesAlive;//敌人存活数
    [Tooltip("允许的最大敌人数")] public int maxEnemiesAllowed;//允许的最大敌人数
    [Tooltip("是否达到最大敌人数")] public bool maxEnemiesReached = false;//是否达到最大敌人数
    [Tooltip("是否启动出怪")] private bool isWaveActive = false;//是否启动出怪

    [Header("敌人生成点")]
    public List<Transform> relativeSpawnPoints;

    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerState>().transform;
        CalculateWaveQuota();
    }

    void Update()
    {
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0 && !isWaveActive)
        {
            StartCoroutine(BeginNextWave());
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        isWaveActive = true;
        yield return new WaitForSeconds(waveInterval);

        if (currentWaveCount < waves.Count - 1)
        {
            isWaveActive = false;
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }

    /// <summary>
    /// 计算敌人波次
    /// </summary>
    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveQuota].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;

    }
    void SpawnEnemies()
    {

        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)//如果当前生成数量小于设定的敌人数量，则让其生成
                {
                    //生成敌人，之后可以把他们改成使用对象池
                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);
                    //Vector2 spawnPosition = new Vector2(player.transform.position.x + Random.Range(-10f, 10f), player.transform.position.y + Random.Range(-10f, 10f));
                    //Instantiate(enemyGroup.enemyPrefab, spawnPosition, Quaternion.identity);
                    enemyGroup.enemyCount++;//增加出怪计时，用于增加波次
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;//增加怪物存活计时器，用于刷新怪物

                    if (enemiesAlive >= maxEnemiesAllowed)//如果怪物存活数大于设定量，则返回
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                }
            }
        }
    }
}
