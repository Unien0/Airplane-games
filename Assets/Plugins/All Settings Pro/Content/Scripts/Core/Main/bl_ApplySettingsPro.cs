using UnityEngine;
using UnityEngine.SceneManagement;

public class bl_ApplySettingsPro : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        bl_ApplySettingsPro script = FindObjectOfType<bl_ApplySettingsPro>();
        if(script != null && script != this) { Destroy(gameObject); return; }

        DontDestroyOnLoad(gameObject);
        bl_AllSettings.Instance.ApplySettings(false);
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChange;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChange;
    }

    private void OnDestroy()
    {
        bl_AllSettings.Instance?.Clear();
    }

    void OnSceneChange(Scene old, Scene newScene)
    {
        bl_AllSettings.Instance.ApplySettings(false);
    }
}