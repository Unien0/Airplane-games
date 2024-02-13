using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleLoadManager : MonoBehaviour
{
    public PlayerData_SO playerData;
    public PlayerBullet_SO bulletData;
    public ShopData_SO shopData;
    public TaskData_SO taskData;
    public CurrentTask_SO currentTask;
    public SwitchData_SO switchData;
    public SaveTimeDate_SO saveTimeDate;

    public TMP_Text loadTime1;
    public TMP_Text loadTime2;
    public TMP_Text loadTime3;
    public TMP_Text loadTime4;

    public TMP_Text displayLoadMoney1;
    public TMP_Text displayLoadMoney2;
    public TMP_Text displayLoadMoney3;
    public TMP_Text displayLoadMoney4;

    public string sceneName;

    private void Update()
    {        
        loadTime1.text = "时间：" + saveTimeDate.time1;
        loadTime2.text = "时间：" + saveTimeDate.time2;
        loadTime3.text = "时间：" + saveTimeDate.time3;
        loadTime4.text = "时间：" + saveTimeDate.time4;
        displayLoadMoney1.text = "$" + saveTimeDate.money1.ToString();
        displayLoadMoney2.text = "$" + saveTimeDate.money2.ToString();
        displayLoadMoney3.text = "$" + saveTimeDate.money3.ToString();
        displayLoadMoney4.text = "$" + saveTimeDate.money4.ToString();
    }

    public void LoadButton1()
    {
        playerData = ES3.Load<PlayerData_SO>("playerData1");
        bulletData = ES3.Load<PlayerBullet_SO>("bulletData1");
        shopData = ES3.Load<ShopData_SO>("shopData1");
        taskData = ES3.Load<TaskData_SO>("taskData1");
        currentTask = ES3.Load<CurrentTask_SO>("currentTask1");
        switchData = ES3.Load<SwitchData_SO>("switchData1");
        saveTimeDate = ES3.Load<SaveTimeDate_SO>("saveTimeDate1");
        SceneManager.LoadScene(sceneName);

    }
    public void LoadButton2()
    {
        playerData = ES3.Load<PlayerData_SO>("playerData2");
        bulletData = ES3.Load<PlayerBullet_SO>("bulletData2");
        shopData = ES3.Load<ShopData_SO>("shopData2");
        taskData = ES3.Load<TaskData_SO>("taskData2");
        currentTask = ES3.Load<CurrentTask_SO>("currentTask2");
        switchData = ES3.Load<SwitchData_SO>("switchData2");
        saveTimeDate = ES3.Load<SaveTimeDate_SO>("saveTimeDate2");
        SceneManager.LoadScene(sceneName);

    }
    public void LoadButton3()
    {
        playerData = ES3.Load<PlayerData_SO>("playerData3");
        bulletData = ES3.Load<PlayerBullet_SO>("bulletData3");
        shopData = ES3.Load<ShopData_SO>("shopData3");
        taskData = ES3.Load<TaskData_SO>("taskData3");
        currentTask = ES3.Load<CurrentTask_SO>("currentTask3");
        switchData = ES3.Load<SwitchData_SO>("switchData3");
        saveTimeDate = ES3.Load<SaveTimeDate_SO>("saveTimeDate3");
        SceneManager.LoadScene(sceneName);

    }
    public void LoadButton4()
    {
        playerData = ES3.Load<PlayerData_SO>("playerData4");
        bulletData = ES3.Load<PlayerBullet_SO>("bulletData4");
        shopData = ES3.Load<ShopData_SO>("shopData4");
        taskData = ES3.Load<TaskData_SO>("taskData4");
        currentTask = ES3.Load<CurrentTask_SO>("currentTask4");
        switchData = ES3.Load<SwitchData_SO>("switchData4");
        saveTimeDate = ES3.Load<SaveTimeDate_SO>("saveTimeDate4");
        SceneManager.LoadScene(sceneName);

    }


}
