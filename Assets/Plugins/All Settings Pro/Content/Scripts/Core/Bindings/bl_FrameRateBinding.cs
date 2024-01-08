using UnityEngine;
using System.Linq;

namespace Lovatto.AllSettings
{
    public class bl_FrameRateBinding : MonoBehaviour
    {
        private bl_SingleSettingsBinding settingsBinding;

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            TryGetComponent(out settingsBinding);
            if(settingsBinding != null)
            {
                var frames = (int[])bl_AllSettings.GetSettingOf("limit-fps-list");
                string[] list = frames.Select(x => x.ToString()).ToArray();
                list[0] = "Unlimited";

                settingsBinding.SetOptions(list);
                settingsBinding.SetSelection(bl_AllSettings.Instance.GetSettingsOf("limit-fps"));
            }
        }

    }
}