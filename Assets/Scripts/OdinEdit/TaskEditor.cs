using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

public class TaskEditor : OdinMenuEditorWindow
{
    [MenuItem("Tools/项目管理/任务管理器")]
    private static void OpenWindow()
    {
        GetWindow<TaskEditor>().Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        tree.Selection.SupportsMultiSelect = false;

        //tree.Add("Create New", new CreateNewTaskData());
        tree.AddAllAssetsAtPath("Task Data", "Assets/SOData/Tesk", typeof(TaskData_SO));
        return tree;
    }

    
}
