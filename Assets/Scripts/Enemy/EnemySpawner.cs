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
        public int waveQuota;
        public float spawnInterval;
        public int spawnCount;

    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
        public GameObject enemyPrefab;

    }
    [Header("波次")]
    public List<Wave> waves;

    [Header("参数")]
    public int currentWaveCount;
    float spawnTimer;
    public float waveInterval;
    public int enemiesAlive;
    public int maxEnemiesAllowed;
    public bool maxEnemiesReached = false;
    private bool isWaveActive = false;

    [Header("敌人生成点")]
    public List<Transform> relativeSpawnPoints;

    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerState>().transform;
        //CalculateWaveQuota();
    }
}
