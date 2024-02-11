using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 用于结算任务
/// </summary>
public class InGameController : MonoBehaviour
{
    public CurrentTask_SO currentTask;
    public CurrentTask_SO currentTaskTarget;
    public PlayerData_SO playerData;

    public void Awake()
    {
        EventCenter.AddListener(EventType.ExterminateTaskClear, TaskClear);
        EventCenter.AddListener(EventType.CollectTaskClear, TaskClear);
        EventCenter.AddListener(EventType.SurvivalTaskClear, TaskClear);
    }

    public void OnDestroy()
    {
        EventCenter.RemoveListener(EventType.ExterminateTaskClear, TaskClear);
        EventCenter.RemoveListener(EventType.CollectTaskClear, TaskClear);
        EventCenter.RemoveListener(EventType.SurvivalTaskClear, TaskClear);
    }

    /// <summary>
    /// 任务结算
    /// </summary>
    public void TaskClear()
    {
        //添加报酬金
        playerData.playerMoney += currentTask.remuneration;

        //清空当前任务
        currentTask.ResetTaskData();
        //返回场景
        SceneManager.LoadScene("Rest");
    }
}
