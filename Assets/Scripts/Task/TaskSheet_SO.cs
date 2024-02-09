using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "TaskSheet_SO", menuName = "Data/TaskSheet")]
[InlineEditor]
public class TaskSheet_SO : ScriptableObject
{
    [Title("任务单")]
    public List<TaskSheet> TaskSheetList;
}

[System.Serializable]
public class TaskSheet
{
    public int taskSheetNamber;
    public int taskID;
    public bool hasTakenOver;//是否已经承接？
}
