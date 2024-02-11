using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

public class TaskManager : MonoBehaviour//单例模式
{
    public TaskData_SO taskListData;
    public TaskSheet_SO taskSheet;
    public CurrentTask_SO currentTaskData;

    [Header("任务总表中，任务的数量")]
    [ReadOnly]
    public int taskListCount;
    private string taskInfo;
    private bool isClear;
    private bool missID;
    
    #region 任务单显示
    [FoldoutGroup("任务清单1", expanded: true)]
    public TMP_Text taskSheetName1;//名称
    [FoldoutGroup("任务清单1", expanded: true)]
    public TMP_Text taskSheetType1;//类型
    [FoldoutGroup("任务清单1", expanded: true)]
    public TMP_Text taskSheetDescription1;//描述
    [FoldoutGroup("任务清单1", expanded: true)]
    public TMP_Text taskSheetTarget1;//目标
    [FoldoutGroup("任务清单1", expanded: true)]
    public TMP_Text taskSheetRemuneration1;//报酬
    [FoldoutGroup("任务清单1", expanded: true)]
    public Button taskSheetReplaceButton1;//替换
    [FoldoutGroup("任务清单1", expanded: true)]
    public Button taskSheetUndertakeButton1;//承接

    [FoldoutGroup("任务清单2", expanded: true)]
    public TMP_Text taskSheetName2;//名称
    [FoldoutGroup("任务清单2", expanded: true)]
    public TMP_Text taskSheetType2;//类型
    [FoldoutGroup("任务清单2", expanded: true)]
    public TMP_Text taskSheetDescription2;//描述
    [FoldoutGroup("任务清单2", expanded: true)]
    public TMP_Text taskSheetTarget2;//目标
    [FoldoutGroup("任务清单2", expanded: true)]
    public TMP_Text taskSheetRemuneration2;//报酬
    [FoldoutGroup("任务清单2", expanded: true)]
    public Button taskSheetReplaceButton2;//替换
    [FoldoutGroup("任务清单2", expanded: true)]
    public Button taskSheetUndertakeButton2;//承接

    [FoldoutGroup("任务清单3", expanded: true)]
    public TMP_Text taskSheetName3;//名称
    [FoldoutGroup("任务清单3", expanded: true)]
    public TMP_Text taskSheetType3;//类型
    [FoldoutGroup("任务清单3", expanded: true)]
    public TMP_Text taskSheetDescription3;//描述
    [FoldoutGroup("任务清单3", expanded: true)]
    public TMP_Text taskSheetTarget3;//目标
    [FoldoutGroup("任务清单3", expanded: true)]
    public TMP_Text taskSheetRemuneration3;//报酬
    [FoldoutGroup("任务清单3", expanded: true)]
    public Button taskSheetReplaceButton3;//替换
    [FoldoutGroup("任务清单3", expanded: true)]
    public Button taskSheetUndertakeButton3;//承接


    #endregion


    #region 机库任务显示
    [FoldoutGroup("机库任务显示", expanded: true)]
    public TMP_Text taskName;
    [FoldoutGroup("机库任务显示", expanded: true)]
    public TMP_Text taskDescription;//描述
    [FoldoutGroup("机库任务显示", expanded: true)]
    public TMP_Text taskTarget;//目标
    [FoldoutGroup("机库任务显示", expanded: true)]
    public TMP_Text taskRemuneration;//报酬
    [FoldoutGroup("机库任务显示", expanded: true)]
    public Button myButton;
    #endregion

    private void Start()
    {
        //获取总表中任务的数量
        taskListCount = taskListData.TaskDetailsList.Count;
        SheetFilling();
    }

    private void Update()
    {
        //机库里当前任务显示
        TaskDataDisplay();
        //任务列表中任务显示
        DisplaySheet1();
        DisplaySheet2();
        DisplaySheet3();
    }

    //任务单回根据对应的ID显示任务

    //1、在任务榜中没有任务的话，往里面填充任务【】
    //2、在承接了任务后替换那个任务榜单中任务
    //3、按下替换键后替换那个任务单中的任务

    /// <summary>
    /// 任务单填充
    /// 在调出的时候启动
    /// </summary>
    void SheetFilling()
    {
        if (taskSheet != null && taskSheet.TaskSheetList != null)
        {
            foreach (var taskSheetEntry in taskSheet.TaskSheetList)
            {
                if (taskSheetEntry.taskID <= 0)
                {
                    taskSheetEntry.taskID = Random.Range(1, taskListCount+1);
                }
            }
        }
    }

    /// <summary>
    /// 替换任务（按钮
    /// </summary>
    public void ReplaceTask(int sheetNumber)
    {
        //找到对应的数
        TaskSheet taskSheetNumberID = taskSheet.TaskSheetList.Find(task => task.taskSheetNamber == sheetNumber);
        if (taskSheetNumberID != null)
        {
            //实现替换
            taskSheetNumberID.taskID = Random.Range(1, taskListCount + 1);
        }
    }

    /// <summary>
    /// 显示任务单中的信息
    /// </summary>
    void DisplaySheet1()
    {
        foreach (var taskSheetEntry in taskSheet.TaskSheetList)
        {
            if (taskSheetEntry.taskSheetNamber == 1)
            {
                // 在TaskDetailsList中查找匹配的任务细节
                TaskDetails taskDetails = taskListData.TaskDetailsList.Find(t => t.taskID == taskSheetEntry.taskID);
                if (taskDetails != null)
                {
                    taskSheetName1.text = taskDetails.taskName;
                    taskSheetType1.text = taskDetails.taskType.ToString();
                    taskSheetDescription1.text = taskDetails.taskDescription;
                    taskSheetRemuneration1.text = taskDetails.remuneration.ToString();

                    string taskInfo1 = null;
                    foreach (var wave in taskDetails.waves)
                    {
                        foreach (var enemyGroup in wave.enemyGroups)
                        {
                            taskInfo1 += $"{enemyGroup.enemyName} 数量: {enemyGroup.enemyCount}\n";
                        }
                    }
                    taskSheetTarget1.text = taskInfo1;
                }
            }
        }
    }
    void DisplaySheet2()
    {
        foreach (var taskSheetEntry in taskSheet.TaskSheetList)
        {
            if (taskSheetEntry.taskSheetNamber == 2)
            {
                // 在TaskDetailsList中查找匹配的任务细节
                TaskDetails taskDetails = taskListData.TaskDetailsList.Find(t => t.taskID == taskSheetEntry.taskID);
                if (taskDetails != null)
                {
                    taskSheetName2.text = taskDetails.taskName;
                    taskSheetType2.text = taskDetails.taskType.ToString();
                    taskSheetDescription2.text = taskDetails.taskDescription;
                    taskSheetRemuneration2.text = taskDetails.remuneration.ToString();

                    string taskInfo2 = null;
                    foreach (var wave in taskDetails.waves)
                    {
                        foreach (var enemyGroup in wave.enemyGroups)
                        {
                            taskInfo2 += $"{enemyGroup.enemyName} 数量: {enemyGroup.enemyCount}\n";
                        }
                    }
                    taskSheetTarget2.text = taskInfo2;
                }
            }
        }
    }
    void DisplaySheet3()
    {
        foreach (var taskSheetEntry in taskSheet.TaskSheetList)
        {
            if (taskSheetEntry.taskSheetNamber == 3)
            {
                // 在TaskDetailsList中查找匹配的任务细节
                TaskDetails taskDetails = taskListData.TaskDetailsList.Find(t => t.taskID == taskSheetEntry.taskID);
                if (taskDetails != null)
                {
                    taskSheetName3.text = taskDetails.taskName;
                    taskSheetType3.text = taskDetails.taskType.ToString();
                    taskSheetDescription3.text = taskDetails.taskDescription;
                    taskSheetRemuneration3.text = taskDetails.remuneration.ToString();

                    string taskInfo3 = null;
                    foreach (var wave in taskDetails.waves)
                    {
                        foreach (var enemyGroup in wave.enemyGroups)
                        {
                            taskInfo3 += $"{enemyGroup.enemyName} 数量: {enemyGroup.enemyCount}\n";
                        }
                    }
                    taskSheetTarget3.text = taskInfo3;
                }
            }
        }
    }

    public TaskDetails GetTaskDetails(int ID)
    {
        return taskListData.TaskDetailsList.Find(i => i.taskID == ID);
    }

    /// <summary>
    /// 获取按钮下任务ID
    /// 需要修改成随机ID
    /// </summary>
    /// <param name="ID"></param>
    public void CopyTaskButton(int sheetNumber)
    {
        TaskSheet taskSheetNumberID = taskSheet.TaskSheetList.Find(task => task.taskSheetNamber == sheetNumber);
        int ID = taskSheetNumberID.taskID;
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
        missID = false;
        // 寻找TaskData_SO中taskID为随机出来的ID的项
        TaskDetails taskDetailsToCopy = source.TaskDetailsList.Find(task => task.taskID == ID);

        // 如果找到了符合条件的项，则复制数据到CurrentTask_SO
        if (taskDetailsToCopy != null)
        {
            //如果不是已完成的任务，那么就出现
            if (!taskDetailsToCopy.taskCompleted)
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
        }
        else
        {
            missID = true;
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

        if (!isClear&& !missID)
        {
            taskInfo = null;//先清空后再复制
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
        else
        {
            taskInfo = null;//如果没有找到对应ID的话内容显示为空
        }

        taskRemuneration.text = "$" + currentTaskData.remuneration ;

        if (!currentTaskData.isMandatoryTask)
        {
            myButton.interactable = true;
        }
        else
        {
            myButton.interactable = false;
        }
    }

    /// <summary>
    /// 清空当前任务内容,按钮控制
    /// </summary>
    public void ClearCurrentTask()
    {
        if (!currentTaskData.isMandatoryTask)
        {
            myButton.interactable = true;
            isClear = true;
            currentTaskData.ResetTaskData();
            taskName.text = "";
            taskDescription.text = "内容：" + "";
            taskTarget.text = "";
            taskRemuneration.text = "";
        }
    }
}
