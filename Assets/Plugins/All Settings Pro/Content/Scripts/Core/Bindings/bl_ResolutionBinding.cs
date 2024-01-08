using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lovatto.AllSettings
{
    [RequireComponent(typeof(bl_SingleSettingsBinding))]
    public class bl_ResolutionBinding : MonoBehaviour
    {
        [HideInInspector] public bl_SingleSettingsBinding settingsBinding;
        public string[] rNames;
        private string oldName = "";

        private void OnEnable()
        {
            if(settingsBinding == null) { settingsBinding = GetComponent<bl_SingleSettingsBinding>(); }

            Resolution[] resolutions = Screen.resolutions;
            rNames = new string[resolutions.Length];

            for (int i = 0; i < resolutions.Length; i++)
            {
                rNames[i] = $"{resolutions[i].width} x {resolutions[i].height}";
            }
            settingsBinding.optionsNames = rNames;

            if(settingsBinding.currentOption == -1)
            {
                Resolution cr = Screen.resolutions[Screen.resolutions.Length - 1];
                settingsBinding.SetText = $"{cr.width} x {cr.height}";
            }
        }

        public void OnChange(bool forward)
        {
            int maxInteractions = 10;
            int currentOption = settingsBinding.currentOption;
            do
            {
                if (forward)
                {
                    currentOption = (currentOption + 1) % settingsBinding.optionsNames.Length;
                }
                else
                {
                    if (currentOption <= 0) { currentOption = settingsBinding.optionsNames.Length - 1; }
                    else { currentOption--; }
                }
                maxInteractions--;
            } while (settingsBinding.optionsNames[currentOption] == oldName || maxInteractions <= 0);

            oldName = settingsBinding.optionsNames[currentOption];
            settingsBinding.currentOption = currentOption;
            settingsBinding.ApplyCurrentValue();
        }
    }
}