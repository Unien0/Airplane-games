using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    [Title("SO引用")]
    public PlayerData_SO playerData;
    public PlayerBullet_SO bulletData;
    public ShopData_SO shopData;
    [Title("TMP文本")]
    public TMP_Text money;
    public TMP_Text HPDisplay,AttackDisplay, BassSpeedDisplay, MaxSpeedDisplay, TurningSpeedDisplay, CoolDownTimeDisplay, BulletExistenceTimeDisplay;
    
    /// <summary>
    /// 进入场景后呼叫相关
    /// </summary>
    void Start()
    {
        EventHandler.CallAfterSceneLoadedEvent();
    }

    void Update()
    {
        PlayerDataDisplay();
    }

    void PlayerDataDisplay()
    {
        money.text = "$"+playerData.playerMoney.ToString();
        HPDisplay.text =playerData.playerMaxHP.ToString("F1");
        AttackDisplay.text =bulletData.playerBulletDamage.ToString("F1");
        BassSpeedDisplay.text =playerData.playerBaseSpeed.ToString("F1");
        MaxSpeedDisplay.text =playerData.playerMaxSpeed.ToString("F1");
        TurningSpeedDisplay.text =playerData.playerTurningSpeed.ToString("F1");
        CoolDownTimeDisplay.text =bulletData.linerBulletCoolDownTime.ToString("F1");
        BulletExistenceTimeDisplay.text =bulletData.linerBulletExistenceTime.ToString("F1");
    }

}
