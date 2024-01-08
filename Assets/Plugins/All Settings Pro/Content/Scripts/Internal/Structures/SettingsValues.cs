using System;
using UnityEngine;

namespace Lovatto.AllSettings
{
    [Serializable]
    public class SettingsValues
    {
        public int qualityLevel = 3;
        public int resolution = -1;
        public FullScreenMode fullScreenMode = FullScreenMode.FullScreenWindow;
        public TextureQualityOptions masterTextureLimit = TextureQualityOptions.High;
        public AntialiasignOptions antialiasing = AntialiasignOptions.x2;
        public AnisotropicFiltering anisotropicFiltering = AnisotropicFiltering.ForceEnable;
        public ShadowQuality shadowQuality = ShadowQuality.All;
        public ShadowResolution shadowResolution = ShadowResolution.High;
        public ShadowProjection shadowProjection = ShadowProjection.CloseFit;
        public ShadowCascadeModes shadowCascade = ShadowCascadeModes.Two;
        public bool softParticles = true;
        public bool realTimeReflections = true;
        public SkinWeights blendWeights = SkinWeights.TwoBones;
        public VSyncOptions vSync = VSyncOptions.DontSync;
        public bool textureStreaming = false;
        public bool showFPS = false;
        public bool audioEnable = true;

        [Range(0, 500)] public float shadowDistance = 40;
        [Range(0.2f, 3)] public float lodBias = 1;
        [Range(0, 1)] public float brightness = 1;
        [Range(0.1f, 1.5f)] public float hudScale = 1;
        [Range(0, 1)] public float volume = 1;

        public int limitFrameRate = 0;
        public int[] limitFrameRates = new int[]
        {
            -1, 30,60,72,144,200
        };

        public bool initializated { get; set; } = false;
    }
}