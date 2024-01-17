using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>//单例模式
{
    public TaskData_SO taskListData;
    public CurrentTask_SO currentTaskData;

    public TaskDetails GetTaskDetails(int ID)
    {
        return taskListData.TaskDetailsList.Find(i => i.taskID == ID);
    }

    public void CopyTaskButton(int ID)
    {
        CopyTaskDataToCurrentTask(taskListData, currentTaskData,ID);
    }

    void CopyTaskDataToCurrentTask(TaskData_SO source, CurrentTask_SO destination,int ID)
    {
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

                    destinationWave.enemyGroups.Add(destinationEnemyGroup);
                }

                destination.waves.Add(destinationWave);
            }

            // 其他参数的复制...
            
        }
        else
        {
            Debug.LogWarning("未找到相应ID的任务");
        }
    }
}
