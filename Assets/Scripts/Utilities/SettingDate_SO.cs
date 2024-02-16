using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "SettingDate_SO", menuName = "Data/SettingData")]
[InlineEditor]
public class SettingDate_SO : ScriptableObject
{
    [Title("画面设置")]
    public bool fullSceen;
    public int setQuality =0;
    [Title("声音设置")]
    public float soundMasterVolume;
    public float soundMusicVolume;
    public float soundSEVolume;


}
