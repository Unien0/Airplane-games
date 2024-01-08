using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Lovatto.AllSettings;

[CustomEditor(typeof(bl_Settings))]
public class bl_SettingsEditor : Editor
{

    bl_Settings script;

    private void OnEnable()
    {
        script = (bl_Settings)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        base.OnInspectorGUI();
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(target);
        }

        GUILayout.Space(5);
        if (string.IsNullOrEmpty(script.GroupName)) return;

        string key = bl_AllSettings.GetUniqueKey(script.GroupName);
        bool hasStore = PlayerPrefs.HasKey(key);
        if (hasStore)
        {
            if(GUILayout.Button("Delete Saved Settings"))
            {
                PlayerPrefs.DeleteKey(key);
            }
        }
    }
}