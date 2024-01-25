using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "SwitchData_SO", menuName = "Data/SwitchData")]
[InlineEditor]
public class SwitchData_SO : ScriptableObject
{
    [Title("游戏开关")]
    public bool gameStart;

    //=====================================
    [FoldoutGroup("新手任务", expanded: true)]
    public bool newbieTask;
    [FoldoutGroup("新手任务", expanded: true)]
    public bool newbieTaskClear;


    //=====================================
}
