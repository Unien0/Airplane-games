using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lovatto.AllSettings;

public class bl_AllSettings : ScriptableObject
{
    [Header("Settings")]
    public bool applySettingsOnChange = false;
    public bool autoSaveSettings = false;
    [Header("Default Settings")]
    [SerializeField] private bl_Settings defaultSettings = null;

    private SettingsValues cacheValues { get; set; } = null;
    public SettingsValues settings
    {
        get
        {
            if (cacheValues == null || !cacheValues.initializated)
            {
                cacheValues = defaultSettings.Get();
                cacheValues.initializated = true;
            }
            return cacheValues;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Clear()
    {
        if (cacheValues != null) cacheValues.initializated = false;
        cacheValues = null;
    }

    /// <summary>
    /// Get the store value of a specific settings
    /// if saved settings are not found the default settings will be returned.
    /// </summary>
    /// <param name="settingKey"></param>
    /// <returns></returns>
    public static object GetSettingOf(string settingKey)
    {
        switch (settingKey)
        {
            case "limit-fps-list":
                return Instance.settings.limitFrameRates;
            default:
                return Instance.GetSettingsOf(settingKey);                
        }
    }

    /// <summary>
    /// Get the store value of a specific settings
    /// if saved settings are not found the default settings will be returned.
    /// </summary>
    /// <returns></returns>
    public int GetSettingsOf(string settingName)
    {
        switch (settingName)
        {
            case "shadows":
                return (int)settings.shadowQuality;
            case "softparticles":
                return AllOptionsKeyPro.BoolToInt(settings.softParticles);
            case "quality":
                return settings.qualityLevel;
            case "resolution":
                return settings.resolution;
            case "fullmode":
                return (int)settings.fullScreenMode;
            case "antialiasing":
                return (int)settings.antialiasing;
            case "texturequality":
                return (int)settings.masterTextureLimit;
            case "aniso":
                return (int)settings.anisotropicFiltering;
            case "swprojection":
                return (int)settings.shadowProjection;
            case "swresolution":
                return (int)settings.shadowResolution;
            case "swcascades":
                return (int)settings.shadowCascade;
            case "rtreflection":
                return AllOptionsKeyPro.BoolToInt(settings.realTimeReflections);
            case "blendweight":
                return (int)settings.blendWeights;
            case "vsync":
                return (int)settings.vSync;
            case "textstreaming":
                return AllOptionsKeyPro.BoolToInt(settings.textureStreaming);
            case "fps":
                return AllOptionsKeyPro.BoolToInt(settings.showFPS);
            case "audio":
                return AllOptionsKeyPro.BoolToInt(settings.audioEnable);
            case "limit-fps":
                return settings.limitFrameRate;
            default:
                Debug.LogWarning($"Settings '{settingName}' has not been assigned.");
                return 0;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetSettingOf(string settingName, int value)
    {
        switch (settingName)
        {
            case "shadows":
                settings.shadowQuality = (ShadowQuality)value;
                break;
            case "softparticles":
                settings.softParticles = AllOptionsKeyPro.IntToBool(value);
                break;
            case "quality":
                settings.qualityLevel = value;
                break;
            case "resolution":
                settings.resolution = value;
                break;
            case "fullmode":
                settings.fullScreenMode = (FullScreenMode)value;
                break;
            case "antialiasing":
                settings.antialiasing = (AntialiasignOptions) value;
                break;
            case "texturequality":
                settings.masterTextureLimit = (TextureQualityOptions)value;
                break;
            case "aniso":
                settings.anisotropicFiltering = (AnisotropicFiltering)value;
                break;
            case "swprojection":
                settings.shadowProjection = (ShadowProjection)value;
                break;
            case "swresolution":
                settings.shadowResolution = (ShadowResolution)value;
                break;
            case "swcascades":
                settings.shadowCascade = (ShadowCascadeModes)value;
                break;
            case "rtreflection":
                settings.realTimeReflections = AllOptionsKeyPro.IntToBool(value);
                break;
            case "blendweight":
                settings.blendWeights = (SkinWeights)value;
                break;
            case "vsync":
                settings.vSync = (VSyncOptions)value;
                break;
            case "textstreaming":
                settings.textureStreaming = AllOptionsKeyPro.IntToBool(value);
                break;
            case "fps":
                settings.showFPS = AllOptionsKeyPro.IntToBool(value);
                break;
            case "audio":
                settings.audioEnable = AllOptionsKeyPro.IntToBool(value);
                break;
            case "limit-fps":
                settings.limitFrameRate = value;
                break;
            default:
                Debug.LogWarning($"Settings '{settingName}' has not been assigned.");
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetFloatValueOf(string settingName)
    {
        switch (settingName)
        {
            case "swdistance":
                return settings.shadowDistance;
            case "lodbias":
                return settings.lodBias;
            case "brightness":
                return settings.brightness;
            case "hudscale":
                return settings.hudScale;
            case "volume":
                return settings.volume;
            default:
                Debug.LogWarning($"Settings '{settingName}' has not been assigned.");
                return 0;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetFloatSettingOf(string settingName, float value)
    {
        switch (settingName)
        {
            case "swdistance":
                settings.shadowDistance = value;
                break;
            case "lodbias":
                settings.lodBias = value;
                break;
            case "brightness":
                settings.brightness = value;
                break;
            case "hudscale":
                settings.hudScale = value;
                break;
            case "volume":
                settings.volume = value;
                break;
            default:
                Debug.LogWarning($"Settings '{settingName}' has not been assigned.");
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void ApplySettings(bool applyResolution)
    {
        SettingsValues sv = settings;
        //QualitySettings.SetQualityLevel(settings.qualityLevel);
        QualitySettings.shadows = sv.shadowQuality;
        QualitySettings.softParticles = sv.softParticles;
        int aalevel = (int)Mathf.Pow(2, Mathf.Clamp((int)sv.antialiasing, 0, 4));
        QualitySettings.antiAliasing = aalevel;
        QualitySettings.masterTextureLimit = (int)sv.masterTextureLimit;
        QualitySettings.anisotropicFiltering = sv.anisotropicFiltering;
        QualitySettings.shadowProjection = sv.shadowProjection;
        QualitySettings.shadowResolution = sv.shadowResolution;
        QualitySettings.shadowCascades = (int)sv.shadowCascade;
        QualitySettings.skinWeights = sv.blendWeights;
        QualitySettings.vSyncCount = (int)sv.vSync;
        QualitySettings.shadowDistance = sv.shadowDistance;
        QualitySettings.lodBias = sv.lodBias;
        QualitySettings.streamingMipmapsActive = sv.textureStreaming;
        QualitySettings.realtimeReflectionProbes = sv.realTimeReflections;

        if(applyResolution)
        ApplyResolution();

        Application.targetFrameRate = sv.limitFrameRates[sv.limitFrameRate];

        bl_BrightnessImage.Instance?.SetValue(sv.brightness);
        bl_FramesPerSecondsPro.Instance?.SetActive(sv.showFPS);
        //hud scale
        bl_CanvasScaler[] allcs = FindObjectsOfType<bl_CanvasScaler>();
        float v = 2 - sv.hudScale;
        foreach (var cs in allcs)
        {
            cs.ScaleTo(v);
        }
        AudioListener.volume = sv.volume;
        AudioListener.pause = !sv.audioEnable;
    }

    /// <summary>
    /// 
    /// </summary>
    public void ApplyResolution()
    {
        Resolution cr = settings.resolution == -1 ? Screen.resolutions[Screen.resolutions.Length - 1] : Screen.resolutions[settings.resolution];
        if(Screen.currentResolution.width != cr.width && Screen.currentResolution.height != cr.height)
        Screen.SetResolution(cr.width, cr.height, true);
        if(Screen.fullScreenMode != settings.fullScreenMode)
        Screen.fullScreenMode = settings.fullScreenMode;
    }

    /// <summary>
    /// Save the current settings
    /// </summary>
    public void SaveSettings()
    {
        //the settings will be save using the default settings GroupName as key
        defaultSettings?.Save(cacheValues);
        ApplySettings(true);
    }

    /// <summary>
    /// The settings will be overwrite with the ones from the Unity profile
    /// QualitySettings -> Levels
    /// </summary>
    public void GetSettingsFromUnityProfiles(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel, false);
        cacheValues = new SettingsValues();
        cacheValues.qualityLevel = qualityLevel;
        cacheValues.shadowQuality = QualitySettings.shadows;
        cacheValues.softParticles = QualitySettings.softParticles;
        cacheValues.shadowResolution = QualitySettings.shadowResolution;
        cacheValues.masterTextureLimit = (TextureQualityOptions)QualitySettings.masterTextureLimit;
        int aaLevel = QualitySettings.antiAliasing > 0 ? (int)(System.Math.Log(QualitySettings.antiAliasing) / System.Math.Log(2)) : 0;
        cacheValues.antialiasing = (AntialiasignOptions)aaLevel;
        cacheValues.anisotropicFiltering = QualitySettings.anisotropicFiltering;
        cacheValues.shadowCascade = (ShadowCascadeModes)QualitySettings.shadowCascades;
        cacheValues.shadowDistance = QualitySettings.shadowDistance;
        cacheValues.shadowProjection = QualitySettings.shadowProjection;
        cacheValues.realTimeReflections = QualitySettings.realtimeReflectionProbes;
        cacheValues.vSync = (VSyncOptions)QualitySettings.vSyncCount;
        cacheValues.blendWeights = QualitySettings.skinWeights;
        cacheValues.textureStreaming = QualitySettings.streamingMipmapsActive;
        cacheValues.lodBias = QualitySettings.lodBias;
    }

    public static string GetUniqueKey(string endPoint)
    {
        string key = $"{Application.productName}.{Application.platform}.{endPoint}";
        return key;
    }


    private static bl_AllSettings _instance;
    public static bl_AllSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load("AllSettings", typeof(bl_AllSettings)) as bl_AllSettings;
            }
            return _instance;
        }
    }
}