using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TestMenuLoad : MonoBehaviour
{
    public string levelToLoad;

    public void Loadc()
    {
        levelToLoad = ES3.Load<string>("NewScene");
        SceneManager.LoadScene(levelToLoad);
    }
}
