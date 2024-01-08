using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lovatto.AllSettings
{
    [Serializable]
    public enum AntialiasignOptions
    {
        Disable = 0,
        x2 = 1, 
        x4 = 2,
        x8 = 3,
        x16 = 4,
    }

    [Serializable]
    public enum TextureQualityOptions
    {
        High = 0,
        Good = 1,
        Regular = 2,
        Low = 3,
    }

    [Serializable]
    public enum ShadowCascadeModes
    {
        None = 0,
        Two = 1,
        Four = 2,
    }

    [Serializable]
    public enum VSyncOptions
    {
        DontSync = 0,
        EveryVBlank = 1,
        EverySecondVBlank = 2,
    }
}