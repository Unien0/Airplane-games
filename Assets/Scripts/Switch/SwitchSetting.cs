using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SwitchSetting : MonoBehaviour
{
    public SwitchData_SO switchData;
    public GameObject SettingBar;
    public GameObject takeObject;
    public GameObject celanObj;
    public Flowchart flowchart;

    private void Awake()
    {
        if (switchData.newbieTaskClear)
        {
            flowchart.SetBooleanVariable("NewPlayer", true);
            takeObject.SetActive(true);
            celanObj.SetActive(false);
            switchData.newbieTaskClear = false;
        }
    }

    public void SettingBarButton()
    {
        if (!SettingBar.activeSelf)
        {
            SettingBar.SetActive(true);
        }
        else
        {
            SettingBar.SetActive(false);
        }
    }
}
