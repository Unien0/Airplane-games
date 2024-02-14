using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//委任イベントのスクリプトについて
public static class EventHandler
{
    #region BGM和SE
    public static event Action AfterSceneLoadedEvent;
    public static void CallAfterSceneLoadedEvent()
    {
        AfterSceneLoadedEvent?.Invoke();
    }

    public static event Action<SoundDetails> InitSoundEffect;
    public static void CallInitSoundEffect(SoundDetails soundDetails)
    {
        InitSoundEffect?.Invoke(soundDetails);
    }

    public static event Action<SoundName> PlaySoundEvent;
    public static void CallPlaySoundEvent(SoundName soundName)
    {
        PlaySoundEvent?.Invoke(soundName);
    }
    #endregion
}
