using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "TaskData_SO", menuName = "Data/Task")]
[InlineEditor]
public class TaskData_SO : ScriptableObject
{
    [Title("任务列表")]
    public List<TaskDetails> TaskDetailsList;
}


[System.Serializable]
public class TaskDetails
{
    [FoldoutGroup("$taskName", expanded: true)]
    [Header("任务数据，ID以1开头")]
    [Header("ID与头像")]
    public int taskID;
    [FoldoutGroup("$taskName", expanded: true)]
    public string taskName;
    [FoldoutGroup("$taskName", expanded: true)]
    public TaskType taskType;
    [FoldoutGroup("$taskName", expanded: true)]
    [LabelWidth(100)]
    [TextArea]
    public string taskDescription;//任务简介

    [Header("任务目标")]
    

    [Header("敌人数量与类型")]
    [FoldoutGroup("$taskName", expanded: true)]
    public List<Wave> waves;

    [System.Serializable]
    public class Wave
    {
        public string waveName;
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

    [FoldoutGroup("$taskName", expanded: true)]
    [Header("参数")]
    [Tooltip("当前波次，默认为0")] public int currentWaveCount;//当前波次
    float spawnTimer;
    [FoldoutGroup("$taskName", expanded: true)]
    [Tooltip("波次间隔")] public float waveInterval;
    [FoldoutGroup("$taskName", expanded: true)]
    [Tooltip("敌人存活数")] public int enemiesAlive;//敌人存活数
    [FoldoutGroup("$taskName", expanded: true)]
    [Tooltip("允许的最大敌人数")] public int maxEnemiesAllowed;//允许的最大敌人数
    [FoldoutGroup("$taskName", expanded: true)]
    [Tooltip("是否达到最大敌人数")] public bool maxEnemiesReached = false;//是否达到最大敌人数
    [FoldoutGroup("$taskName", expanded: true)]
    [Tooltip("是否启动出怪")] public bool isWaveActive = false;//是否启动出怪
    [FoldoutGroup("$taskName", expanded: true)]
    [Header("任务报酬")]
    public int remuneration;
    [FoldoutGroup("$taskName", expanded: true)]
    [Header("任务状态")]
    public bool onTask;
    [FoldoutGroup("$taskName", expanded: true)]
    [Header("任务是否完成（是否重复出现）")]
    public bool taskCompleted;
    [FoldoutGroup("$taskName", expanded: true)]
    [Header("任务启用，主线任务使用")]
    public bool taskOpened;
    [FoldoutGroup("$taskName", expanded: true)]
    [Header("是否是强制任务")]
    public bool isMandatoryTask;
}


