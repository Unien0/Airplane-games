using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    // Gets the filename with the slot appended.
    string filename
    {
        get { return "SaveFile" + SaveSlot.slot + ".es3"; }
    }

    public const string loadScene = "MainMenu";
    private MoveRandomly bull;

    void Awake()
    {
        //获取组件
        bull = this.gameObject.GetComponent<MoveRandomly>();
        //通过事件系统调用方法
        EventCenter.AddListener(EventType.Save, Save);
        EventCenter.AddListener(EventType.Load, Load);
        
    }
    private void Start()
    {
        //启动时调用读取(需要专门的SaveManager），正常需要在Awake中调用，防止出现OnEnable错误
        EventCenter.Broadcast(EventType.Load);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //场景移动时保存
            EventCenter.Broadcast(EventType.Save);
            SceneManager.LoadScene(loadScene);
        }
    }

    void Save()
    {
        ES3.Save("position", transform.position, filename);
        ES3.Save("number", bull.number, filename);
    }

    void Load( )
    {
        //根据对应存档加载，存档位置 = filename
        if (ES3.KeyExists("position", filename))
            transform.position = ES3.Load<Vector3>("position", filename);
            bull.number = ES3.Load<int>("number", filename);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventType.Load, Load);
        EventCenter.RemoveListener(EventType.Save, Save);
    }

    /// <summary>
    /// 自动保存之推出游戏时保存
    /// </summary>
    // This will be called when the application quits.
    // Note that this isn't called on all platforms.
    void OnApplicationQuit()
    {
        
        // Save our data, appending our save slot to the filename.
        ES3.Save("position", transform.position, filename);
        ES3.Save("number", bull.number, filename);
    }
}
