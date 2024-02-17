using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

/// <summary>
/// 用于结算任务
/// </summary>
public class InGameController : MonoBehaviour
{
    public TaskData_SO taskData;
    public CurrentTask_SO currentTask;
    public PlayerData_SO playerData;
    public GameObject stopCanvas;
    public GameObject treasureObj;
    bool stop;
    bool newPlayerBool;
    public Flowchart flowchart;

    public void Awake()
    {
        EventCenter.AddListener(EventType.ExterminateTaskClear, TaskClear);
        EventCenter.AddListener(EventType.CollectTaskClear, TaskClear);
        EventCenter.AddListener(EventType.SurvivalTaskClear, TaskClear);
        if (currentTask.taskID == 1)
        {
            flowchart.SetBooleanVariable("newPlayer", true);
            Time.timeScale = 0;
        }
    }

    public void OnDestroy()
    {
        EventCenter.RemoveListener(EventType.ExterminateTaskClear, TaskClear);
        EventCenter.RemoveListener(EventType.CollectTaskClear, TaskClear);
        EventCenter.RemoveListener(EventType.SurvivalTaskClear, TaskClear);
    }
    private void Start()
    {
        EventHandler.CallAfterSceneLoadedEvent();
        if (currentTask.taskType == TaskType.collect)
        {
            treasureObj.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ButtonStop();
        }
        Explanationed();
    }
    public void Explanationed()
    {
        if (flowchart.GetBooleanVariable("explanationed") && !newPlayerBool)
        {
            Time.timeScale = 1;
            newPlayerBool = true;
            flowchart.SetBooleanVariable("newPlayer", false);
        }
    }

    /// <summary>
    /// 任务结算
    /// </summary>
    public void TaskClear()
    {
        //添加报酬金
        playerData.playerMoney += currentTask.remuneration;
        //不重复任务情况下将任务总表的对应id项目确认，防止再次出现（比如新手任务
        if (currentTask.isMandatoryTask)
        {
            int ID = currentTask.taskID;
            TaskDetails taskDetailsToCopy = taskData.TaskDetailsList.Find(task => task.taskID == ID);
            taskDetailsToCopy.taskCompleted = true;
        }

        //清空当前任务
        currentTask.ResetTaskData();
        //返回场景
        SceneManager.LoadScene("Rest");
    }

    public void ButtonStop()
    {
        if (!stop)
        {
            stop = true;
            stopCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            stop = false;
            stopCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ButtonToRest()
    {
        SceneManager.LoadScene("Rest");
    }

    public void ButtonGameOver()
    {
        Application.Quit();
    }
}
