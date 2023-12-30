using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SimpleSave : MonoBehaviour
{
    public GameObject player;
    public PlayerData_SO testData;

    /// <summary>
    /// 按钮触发方法
    /// </summary>
    public void Save()
    {
        TestPM testPM = player.GetComponent<TestPM>();
        //ES3.Save("Transform",testPM.transform);
        ES3.Save("MoveSpeed", testPM.MoveSpeed);
        ES3.Save("playerPosition", player.transform.position);
        ES3.Save("NewScene", SceneManager.GetActiveScene().name);
        ES3.Save("DataSO", testData);
    }

    
}
