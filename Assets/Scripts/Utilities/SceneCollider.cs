using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCollider : MonoBehaviour
{
    //�V�[����ς��ׂɁA�{�^����ʂ��̂��֘A����
    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }
    //�Q�[���I�[�o�[�{�^���Ɋ֘A����
    public void GameOver()
    {
        Application.Quit();
    }

    public void ClearSceneChange()
    {
        SceneManager.LoadScene("Clear");
    }
}