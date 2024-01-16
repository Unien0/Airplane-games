﻿using System.Collections;
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
    [Header("任务数据，ID以1开头")]
    [Header("ID与头像")]
    public string taskID;
    public string taskName;
    public TaskType taskType;
    [LabelWidth(100)]
    [TextArea]
    public string taskDescription;//任务简介

    [Header("任务目标")]
    

    [Header("敌人数量与类型")]
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
        public string enemyName;
        [Tooltip("敌人数")] public int enemyCount;//敌人数
        [Tooltip("波数")] public int spawnCount;//生成数
        public GameObject enemyPrefab;

    }

    [Header("任务状态")]
    public bool onTask;
    public bool taskCompleted;
}


