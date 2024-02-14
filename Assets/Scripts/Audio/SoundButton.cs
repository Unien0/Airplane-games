using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public void ButtonSound()
    {
        EventHandler.CallPlaySoundEvent(SoundName.Button);
    }

    public void ButtonBuy()
    {
        EventHandler.CallPlaySoundEvent(SoundName.ShopBuy);

    }
}
