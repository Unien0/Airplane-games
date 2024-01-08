#define TMP
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
#if TMP
using TMPro;
#endif

namespace Lovatto.AllSettings
{
    public class bl_SingleSettingsBinding : MonoBehaviour
    {
        [Header("Settings")]
        public string SettingKeyName = "";
        public string[] optionsNames = new string[] { "Disable", "Enable" };
        public bool autoUpperCase = false;

        [Header("Listener")]
        public OnChange onChange;

        public int currentOption { get; set; } = 0;

        [System.Serializable] public class OnChange : UnityEvent<int> { }

        [Header("References")]
        public Text optionText;
#if TMP
        public TextMeshProUGUI optionTextTMP;
#endif
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
        public void Load()
        {
            if (!string.IsNullOrEmpty(SettingKeyName))
            {
                currentOption = bl_AllSettings.Instance.GetSettingsOf(SettingKeyName);
                ApplyCurrentValue();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ApplyCurrentValue(bool applySetting = true)
        {
            if (currentOption == -1) return;
            if (currentOption >= optionsNames.Length) return;

            string value = autoUpperCase ? optionsNames[currentOption].ToUpper() : optionsNames[currentOption];
          if(optionText != null) optionText.text = value;
#if TMP
           if(optionTextTMP != null) optionTextTMP.text = value;
#endif
           if(applySetting) ApplySetting();

            if (bl_AllSettings.Instance.autoSaveSettings && applySetting)
                SaveValue();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ApplySetting()
        {
            //Set the changed setting value to the instance settings group.
            bl_AllSettings.Instance.SetSettingOf(SettingKeyName, currentOption);
            onChange?.Invoke(currentOption);
            if (bl_AllSettings.Instance.applySettingsOnChange)
            {
                //call the listener that will apply the settings in game
                bl_AllSettings.Instance.ApplySettings(false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ChangeOption(bool forward)
        {
            if (forward)
            {
                currentOption = (currentOption + 1) % optionsNames.Length;
            }
            else
            {
                if (currentOption <= 0) { currentOption = optionsNames.Length - 1; }
                else { currentOption--; }
            }
            ApplyCurrentValue();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetOptions(string[] newOptions)
        {
            optionsNames = newOptions;
            currentOption = 0;
            ApplyCurrentValue(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSelection(int newSelection, bool applySetting = false)
        {
            if (newSelection < 0 || newSelection > optionsNames.Length - 1) return;

            currentOption = newSelection;
            ApplyCurrentValue(applySetting);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveValue()
        {
            bl_AllSettings.Instance.SaveSettings();
        }

        public string SetText
        {
            get
            {
                return optionText.text;
            }
            set
            {
#if TMP
                if (optionTextTMP != null) optionTextTMP.text = value;
                if (optionText != null) optionText.text = value;
#else
                if (optionText != null) optionText.text = value;
#endif
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
#if TMP
            if (optionText == null && optionTextTMP == null) return;
#else
           if (optionText == null) return;
#endif
            if (optionsNames == null || optionsNames.Length <= 0) return;
            if (currentOption >= optionsNames.Length) { currentOption = 0; return; }

            string value = autoUpperCase ? optionsNames[currentOption].ToUpper() : optionsNames[currentOption];
            if (optionText != null) optionText.text = value;
#if TMP
            if(optionTextTMP != null) optionTextTMP.text = value;
#endif
        }
#endif
    }
}