using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemySpawner : MonoBehaviour
{
    public CurrentTask_SO currentTaskData;
    public CurrentTask_SO currentTaskTarget;

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        //public List<GameObject> enemyPrefabs;
        //public List<string> enemyName;
        //public List<int> enemyCount;
        [Header("敌人类型")]
        public List<EnemyGroup> enemyGroups;
        [Tooltip("在波次中生成的敌人总数，不能为0")] public int waveQuota;
        [Tooltip("生成间隔")] public float spawnInterval;//生成间隔
        [Tooltip("已生成敌人数，默认为0")] public int spawnCount;

    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyID;
        public string enemyName;
        [Tooltip("敌人数")] public int enemyCount;//敌人数
        [Tooltip("波数")] public int spawnCount;//生成数
        public GameObject enemyPrefab;

    }
    [System.Serializable]
    public class TargetGroup
    {
        public string targetEnemyID;
        public int targetEnemyCount;
    }

    [Header("波次")]
    public List<Wave> waves;

    [Header("参数")]
    [Tooltip("当前波次，默认为0")] public int currentWaveCount;//当前波次
    float spawnTimer;
    [Tooltip("波次间隔")] public float waveInterval;
    [Tooltip("敌人存活数")]public int enemiesAlive;//敌人存活数
    [Tooltip("允许的最大敌人数")] public int maxEnemiesAllowed;//允许的最大敌人数
    [Tooltip("是否达到最大敌人数")] public bool maxEnemiesReached = false;//是否达到最大敌人数
    [Tooltip("是否启动出怪")] private bool isWaveActive = false;//是否启动出怪

    [Header("目标达成数")]
    public List<TargetGroup> targetWaves = new List<TargetGroup>();

    [Header("敌人生成点")]
    public List<Transform> relativeSpawnPoints;

    Transform player;
    private EnemyPool enemyPool;

    private void Awake()
    {
        //在最开始的时候确认目标数量
        StatisticalTargetQuantity();
    }

    void Start()
    {
        VariableBinding();
        player = FindObjectOfType<PlayerState>().transform;
        enemyPool = FindObjectOfType<EnemyPool>();//绑定对象池
        CalculateWaveQuota();//游戏开始时候运行，用于生成第一波敌人
    }

    void Update()
    {
        //当前波次数量小于设定的波次， 且可生成量=0，且未出于生成状态时
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0 && !isWaveActive)
        {
            StartCoroutine(BeginNextWave());//利用协成开始下一波
        }

        //设置计时器，如果时间=0时生成敌人
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    /// <summary>
    /// 变量绑定
    /// </summary>
    void VariableBinding()
    {
        waves.Clear(); // 清空当前波次列表

        foreach (var currentWave in currentTaskData.waves)
        {
            Wave newWave = new Wave
            {
                waveName = currentWave.waveName,
                waveQuota = currentWave.waveQuota,
                spawnInterval = currentWave.spawnInterval,
                spawnCount = currentWave.spawnCount,
                enemyGroups = new List<EnemyGroup>()
            };

            foreach (var currentEnemyGroup in currentWave.enemyGroups)
            {
                EnemyGroup newEnemyGroup = new EnemyGroup
                {
                    enemyID = currentEnemyGroup.enemyID,
                    enemyName = currentEnemyGroup.enemyName,
                    enemyCount = currentEnemyGroup.enemyCount,
                    spawnCount = currentEnemyGroup.spawnCount,
                    enemyPrefab = currentEnemyGroup.enemyPrefab
                };

                newWave.enemyGroups.Add(newEnemyGroup);
            }
            waves.Add(newWave);
        }
        waveInterval = currentTaskData.waveInterval;
        maxEnemiesAllowed = currentTaskData.maxEnemiesAllowed;
    }


    /// <summary>
    /// 开始下一波
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// 敌人生成
    /// </summary>
    void SpawnEnemies()
    {
        //如果敌人数量小于额定数量，且未到达最大数量时
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {
            //循环敌人类型
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)//如果当前生成数量小于设定的敌人数量，则让其生成
                {
                    if (enemiesAlive >= maxEnemiesAllowed)//如果怪物存活数大于设定量，则返回
                    {
                        maxEnemiesReached = true;
                        return;
                    }
                    int PointsCount = relativeSpawnPoints.Count;//敌人生成点列表的数量

                    //生成敌人，之后可以把他们改成使用对象池
                    //Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, PointsCount)].position, Quaternion.identity);

                    //对象池方法
                    var enemyP = enemyPool.Get();//取出敌人
                    enemyP.transform.position = player.position + relativeSpawnPoints[Random.Range(0, PointsCount)].position;
                    enemyP.transform.rotation = Quaternion.identity;

                    //Vector2 spawnPosition = new Vector2(player.transform.position.x + Random.Range(-10f, 10f), player.transform.position.y + Random.Range(-10f, 10f));
                    //Instantiate(enemyGroup.enemyPrefab, spawnPosition, Quaternion.identity);
                    enemyGroup.spawnCount++;//增加出怪计时，用于增加波次
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;//增加怪物存活计时器，用于刷新怪物
                }
            }
        }
        //重新生成
        if (enemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }
    /// <summary>
    /// 敌人死亡时候调用
    /// </summary>
    public void OnEnemyKilled(string enemyID)
    {
        enemiesAlive--;

        // 遍历目标列表，找到对应的敌人 ID，并将数量减一
        for (int i = 0; i < targetWaves.Count; i++)
        {
            if (targetWaves[i].targetEnemyID == enemyID)
            {
                targetWaves[i].targetEnemyCount--;
                // 如果数量小于等于 0，可以选择移除该目标或者执行其他操作
                // 这里假设数量小于等于 0 时从列表中移除该目标
                if (targetWaves[i].targetEnemyCount <= 0)
                {
                    targetWaves.RemoveAt(i);
                }
                break;
            }
        }

        // 检查是否所有 EnemyID 对应的 targetEnemyCount 都为 0
        bool allClear = true; // 假设全部为 0
        foreach (var id in GetDistinctEnemyIDs())
        {
            bool found = false;
            foreach (var target in targetWaves)
            {
                if (target.targetEnemyID == id && target.targetEnemyCount > 0)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                allClear = false;
                break;
            }
        }

        // 如果所有 EnemyID 对应的 targetEnemyCount 都为 0，则发送命令
        if (allClear && currentTaskData.taskType == TaskType.exterminate)
        {
            EventCenter.Broadcast(EventType.ExterminateTaskClear);
        }
    }

    // 获取目标列表中出现的所有 EnemyID
    private IEnumerable<string> GetDistinctEnemyIDs()
    {
        HashSet<string> enemyIDs = new HashSet<string>();
        foreach (var target in targetWaves)
        {
            enemyIDs.Add(target.targetEnemyID);
        }
        return enemyIDs;
    
}

    /// <summary>
    /// 统计目标数量
    /// </summary>
    public void StatisticalTargetQuantity()
    {
        // 清空目标达成数列表
        targetWaves.Clear();

        // 创建一个字典来存储每个敌人类型的总生成数
        Dictionary<string, int> enemyCounts = new Dictionary<string, int>();

        // 计算每个敌人类型的总生成数
        foreach (var wave in waves)
        {
            foreach (var enemyGroup in wave.enemyGroups)
            {
                if (enemyCounts.ContainsKey(enemyGroup.enemyID))
                {
                    enemyCounts[enemyGroup.enemyID] += enemyGroup.enemyCount;
                }
                else
                {
                    enemyCounts.Add(enemyGroup.enemyID, enemyGroup.enemyCount);
                }
            }
        }

        // 将结果添加到目标达成数列表中
        foreach (var kvp in enemyCounts)
        {
            TargetGroup targetGroup = new TargetGroup();
            targetGroup.targetEnemyID = kvp.Key;
            targetGroup.targetEnemyCount = kvp.Value;
            targetWaves.Add(targetGroup);
        }
    }
}
