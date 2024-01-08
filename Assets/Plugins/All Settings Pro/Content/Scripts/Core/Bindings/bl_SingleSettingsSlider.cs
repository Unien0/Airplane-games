#define TMP
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
#if TMP
using TMPro;
#endif

public class bl_SingleSettingsSlider : MonoBehaviour
{
    [Header("Settings")]
    public string SettingKeyName = "";
    public string valueFormat = "{0}";

    [Header("References")]
    public Slider slider;
    public Text valueText;
#if TMP
    public TextMeshProUGUI valueTextTMP;
#endif

    public float currentValue { get; set; } = 0;

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        Load();
    }

    /// <summary>
    /// 
    /// </summary>
    void Load()
    {
        currentValue = bl_AllSettings.Instance.GetFloatValueOf(SettingKeyName);
        slider.value = currentValue;
        ApplyCurrentValue();
    }

    /// <summary>
    /// 
    /// </summary>
    public void ApplyCurrentValue()
    {
        if(valueText != null)
            valueText.text = string.Format(valueFormat, slider.value.ToString("0.0"));
#if TMP
        if (valueTextTMP != null)valueTextTMP.text = string.Format(valueFormat, slider.value.ToString("0.0"));
#endif
        ApplySetting();

        if (bl_AllSettings.Instance.autoSaveSettings)
            SaveValue();
    }

    /// <summary>
    /// 
    /// </summary>
    public void ApplySetting()
    {
        //Set the changed setting value to the instance settings group.
        bl_AllSettings.Instance.SetFloatSettingOf(SettingKeyName, currentValue);
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateValue(float value)
    {
        currentValue = value;
        ApplyCurrentValue();
    }

    /// <summary>
    /// 
    /// </summary>
    public void SaveValue()
    {
        bl_AllSettings.Instance.SaveSettings();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (slider == null) return;

        if (valueText != null)
            valueText.text = string.Format(valueFormat, slider.value.ToString("0.0"));
#if TMP
        if (valueTextTMP != null) valueTextTMP.text = string.Format(valueFormat, slider.value.ToString("0.0"));
#endif
    }
#endif
}