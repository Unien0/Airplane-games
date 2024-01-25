using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour//单例模式
{
    public TaskData_SO taskListData;
    public CurrentTask_SO currentTaskData;

    private string taskInfo;
    private bool isClear;

    public TMP_Text taskName;
    public TMP_Text taskDescription;
    public TMP_Text taskTarget;
    public TMP_Text taskRemuneration;

    public Button myButton;
    private Color originalColor;

    private void Start()
    {
        // 记录按钮原始颜色
        originalColor = myButton.colors.normalColor;
    }

    private void Update()
    {
        TaskDataDisplay();
    }


    public TaskDetails GetTaskDetails(int ID)
    {
        return taskListData.TaskDetailsList.Find(i => i.taskID == ID);
    }

    public void CopyTaskButton(int ID)
    {
        CopyTaskDataToCurrentTask(taskListData, currentTaskData,ID);
    }

    /// <summary>
    /// 复制任务从任务总表至当前任务SO
    /// </summary>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <param name="ID"></param>
    void CopyTaskDataToCurrentTask(TaskData_SO source, CurrentTask_SO destination,int ID)
    {
        isClear = false;
        // 寻找TaskData_SO中taskID为1的项
        TaskDetails taskDetailsToCopy = source.TaskDetailsList.Find(task => task.taskID == ID);

        // 如果找到了符合条件的项，则复制数据到CurrentTask_SO
        if (taskDetailsToCopy != null)
        {
            destination.taskID = taskDetailsToCopy.taskID.ToString();
            destination.taskName = taskDetailsToCopy.taskName;
            destination.taskType = taskDetailsToCopy.taskType;
            destination.taskDescription = taskDetailsToCopy.taskDescription;
            destination.waves = new List<CurrentTask_SO.Wave>();

            // 复制每个Wave
            foreach (TaskDetails.Wave sourceWave in taskDetailsToCopy.waves)
            {
                CurrentTask_SO.Wave destinationWave = new CurrentTask_SO.Wave
                {
                    waveName = sourceWave.waveName,
                    enemyGroups = new List<CurrentTask_SO.EnemyGroup>()
                };

                // 复制每个EnemyGroup
                foreach (TaskDetails.EnemyGroup sourceEnemyGroup in sourceWave.enemyGroups)
                {
                    CurrentTask_SO.EnemyGroup destinationEnemyGroup = new CurrentTask_SO.EnemyGroup
                    {
                        enemyID = sourceEnemyGroup.enemyID,
                        enemyName = sourceEnemyGroup.enemyName,
                        enemyCount = sourceEnemyGroup.enemyCount,
                        spawnCount = sourceEnemyGroup.spawnCount,
                        enemyPrefab = sourceEnemyGroup.enemyPrefab
                    };
                    //添加复制的列表
                    destinationWave.enemyGroups.Add(destinationEnemyGroup);
                }

                destination.waves.Add(destinationWave);
            }

            // 其他参数的复制...
           
            destination.waveInterval = taskDetailsToCopy.waveInterval;
            destination.maxEnemiesAllowed = taskDetailsToCopy.maxEnemiesAllowed;
            destination.remuneration = taskDetailsToCopy.remuneration;
            destination.taskCompleted = taskDetailsToCopy.taskCompleted;
            destination.isMandatoryTask = taskDetailsToCopy.isMandatoryTask;
        }
        else
        {
            Debug.LogWarning("未找到相应ID的任务");
        }
    }

    /// <summary>
    /// 当前任务内容显示
    /// </summary>
    void TaskDataDisplay()
    {
        taskName.text = currentTaskData.taskName;
        taskDescription.text = "内容："+currentTaskData.taskDescription;

        if (!isClear)
        {
            if (taskInfo == null && currentTaskData != null)
            {
                foreach (var wave in currentTaskData.waves)
                {
                    foreach (var enemyGroup in wave.enemyGroups)
                    {
                        taskInfo += $"{enemyGroup.enemyName} 数量: {enemyGroup.enemyCount}\n";
                    }
                }
            }
            taskTarget.text = taskInfo;
        }
        
        taskRemuneration.text = "$" + currentTaskData.remuneration ;
    }

    /// <summary>
    /// 清空当前任务内容,按钮控制
    /// </summary>
    public void ClearCurrentTask()
    {
        if (!currentTaskData.isMandatoryTask)
        {
            isClear = true;
            currentTaskData.ResetTaskData();
            taskName.text = "";
            taskDescription.text = "内容：" + "";
            taskTarget.text = "";
            taskRemuneration.text = "";
        }
        else
        {
            // 将按钮颜色更改为红色
            ColorBlock colors = myButton.colors;
            colors.normalColor = Color.red;
            myButton.colors = colors;

            // 启动协程，在两秒后将颜色还原
            StartCoroutine(RestoreColorAfterDelay(2f));
        }

        IEnumerator RestoreColorAfterDelay(float delay)
        {
            // 等待指定的时间
            yield return new WaitForSeconds(delay);

            // 将按钮颜色还原为原始颜色
            ColorBlock colors = myButton.colors;
            colors.normalColor = originalColor;
            myButton.colors = colors;
        }
    }
}
