using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lovatto.AllSettings
{
    [RequireComponent(typeof(bl_SingleSettingsBinding))]
    public class bl_OverallSettingsBinding : MonoBehaviour
    {
        [HideInInspector] public bl_SingleSettingsBinding settingsBinding;
       // private bool pendingCall = false;

        public void OnChangeOverall(int value)
        {
          /*  if (pendingCall) { pendingCall = false; return; }

            pendingCall = true;
            bl_AllSettings.Instance.GetSettingsFromUnityProfiles(value);
            bl_SingleSettingsBinding[] allBindings = FindObjectsOfType<bl_SingleSettingsBinding>();
            foreach(var s in allBindings)
            {
                s.Load();
            }*/
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if(settingsBinding == null) { settingsBinding = GetComponent<bl_SingleSettingsBinding>(); }
            if (settingsBinding == null) return;

            string[] settingsNames = QualitySettings.names;
            settingsBinding.optionsNames = settingsNames;
            int current = QualitySettings.GetQualityLevel();
            settingsBinding.currentOption = current;
        }
#endif
    }
}