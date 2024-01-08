using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lovatto.AllSettings
{
    [CreateAssetMenu(fileName = "Settings", menuName = "All Settings/Settings" )]
    public class bl_Settings : ScriptableObject
    {
        public string GroupName = "";
        public SettingsValues settings;

        /// <summary>
        /// Save the 
        /// </summary>
        public void Save(SettingsValues settingsInstance)
        {
            string key = bl_AllSettings.GetUniqueKey(GroupName);
            string data = JsonUtility.ToJson(settingsInstance);

            PlayerPrefs.SetString(key, data);
        }

        /// <summary>
        /// Try to get the saved settings (a instance of it), if they are not found
        /// the default settings will be returned
        /// </summary>
        /// <returns></returns>
        public SettingsValues Get()
        {
            string key = bl_AllSettings.GetUniqueKey(GroupName);
            if (PlayerPrefs.HasKey(key))
            {
                return JsonUtility.FromJson<SettingsValues>(PlayerPrefs.GetString(key));
            }
            else
            {
                return settings;
            }
        }
    }
}