using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

public class TheGameManager : OdinMenuEditorWindow
{
    [LabelText("Manager View")]
    [LabelWidth(100f)]
    [EnumToggleButtons]
    [ShowInInspector]
    private ManagerState managerState;

    [MenuItem("Tools/游戏管理器")]
    public static void OpenWindow()
    {
        GetWindow<TheGameManager>().Show();
    }
    //protected override void OnGUI()
    //{
    //    base.OnGUI();
    //}

    protected override void DrawEditors()
    {
        base.DrawEditors();
    }

    protected override IEnumerable<object> GetTargets()
    {
        return base.GetTargets();
    }

    protected override void DrawMenu()
    {
        base.DrawMenu();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        OdinMenuTree tree = new OdinMenuTree();
        return tree;
    }
    public enum ManagerState
    {
        universe,
        task,
        pool,
        sfx,

    }
}
