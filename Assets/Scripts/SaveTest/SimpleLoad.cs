using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SimpleLoad : MonoBehaviour
{
    public GameObject player;
    public PlayerData_SO dataSO;
    private void Start()
    {
        //Load();
    }

    public void Load()
    {
        TestPM testPM = player.GetComponent<TestPM>();
        testPM.MoveSpeed = ES3.Load<float>("MoveSpeed", 0);
        player.transform.position = ES3.Load<Vector3>("playerPosition", Vector3.zero);//加载数据，否则来到原点
        dataSO = ES3.Load<PlayerData_SO>("DataSO");
    }
}
