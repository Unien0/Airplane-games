using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSetting : MonoBehaviour
{
    public GameObject SettingBar;

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
