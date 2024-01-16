using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

public class TaskEditor : OdinMenuEditorWindow
{
    [MenuItem("Tools/项目管理/任务管理器")]
    public static void OpenWindow()
    {
        GetWindow<TaskEditor>().Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        OdinMenuTree tree = new OdinMenuTree();
        tree.AddAllAssetsAtPath("Task Data", "Assets/Scripts/SOData/Tesk", typeof(TaskData_SO));
        return tree;
    }
}
