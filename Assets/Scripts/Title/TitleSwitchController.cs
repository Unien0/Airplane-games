using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class TitleSwitchController : MonoBehaviour
{
    public SettingDate_SO settingData;
    public TMP_Dropdown qualityDropdown;
    public AudioMixer audioMixer;
    /// <summary>
    /// 游戏启动时读取画面和声音设置
    /// </summary>
    private void Awake()
    {
        settingData = ES3.Load<SettingDate_SO>("settingData");
        SetImageQuality(settingData.setQuality);
        SetMasterVolume(settingData.soundMasterVolume);
        SetMusicVolume(settingData.soundMusicVolume);
        SetSEVolume(settingData.soundSEVolume);
        FullScreen();
    }

    private void OnDestroy()
    {
        ES3.Save("settingData", settingData);
    }

    private void Start()
    {
        ES3.Save("settingData", settingData);
    }

    #region 全屏设置
    public void ToggleFullScreen()
    {
        if (settingData.fullSceen)
        {
            //退出全屏
            settingData.fullSceen = false;
            FullScreen();
        }
        else
        {
            //进入全屏
            settingData.fullSceen = true;
            FullScreen();
        }
    }

    void FullScreen()
    {
        if (!settingData.fullSceen)
        {
            //退出全屏
            Screen.fullScreen = false;
            ES3.Save("settingData", settingData);
        }
        else
        {
            //设置全屏
            //获取设置当前屏幕分辩率  
            Resolution[] resolutions = Screen.resolutions;
            //设置当前分辨率  
            Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);
            Screen.fullScreen = true;
            ES3.Save("settingData", settingData);
        }
    }

    #endregion

    #region 画质设置
    public void DropDownChange()
    {
        SetImageQuality(qualityDropdown.value);
    }

    private void SetImageQuality(int index)
    {
        switch (index)
        {
            case 0:
                if (settingData.fullSceen)
                {
                    Screen.SetResolution(1920, 1080, true);
                }
                else
                {
                    Screen.SetResolution(1920, 1080, false);
                }
                
                settingData.setQuality = 0;
                ES3.Save("settingData", settingData);
                break;
            case 1:
                if (settingData.fullSceen)
                {
                    Screen.SetResolution(1600, 900, true);
                }
                else
                {
                    Screen.SetResolution(1600, 900, false);
                }
                
                settingData.setQuality = 1;
                ES3.Save("settingData", settingData);
                break;
            case 2:
                if (settingData.fullSceen)
                {
                    Screen.SetResolution(1280, 720, true);
                }
                else
                {
                    Screen.SetResolution(1280, 720, false);
                }
                
                settingData.setQuality = 2;
                ES3.Save("settingData", settingData);
                break;
        }
    }


    #endregion

    #region 音量设置
    public void SetMasterVolume(float volume)    // 控制主音量的函数
    {
        audioMixer.SetFloat("MasterVolume", volume);
        settingData.soundMasterVolume = volume;
        ES3.Save("settingData", settingData);

    }

    public void SetMusicVolume(float volume)    // 控制背景音乐音量的函数
    {
        audioMixer.SetFloat("MusicVolume", volume);
        settingData.soundMusicVolume = volume;
        ES3.Save("settingData", settingData);
    }

    public void SetSEVolume(float volume)    // 控制音效音量的函数
    {
        audioMixer.SetFloat("SEVolume", volume);
        settingData.soundSEVolume = volume;
        ES3.Save("settingData", settingData);
    }
    #endregion
}
