using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDataGeting : MonoBehaviour
{
    public PlayerData_SO playerData;
    public PlayerBullet_SO bulletData;
    public TMP_Text hp;
    public TMP_Text damage;
    public TMP_Text baseSpeed;
    public TMP_Text maxSpeed;
    public TMP_Text turningSpeed;
    public TMP_Text attackSpeed;
    public TMP_Text attackDistance;

    void Update()
    {
        hp.text = playerData.playerMaxHP.ToString();
        damage.text = playerData.playerBaseDamege.ToString("F1");
        baseSpeed.text = playerData.playerBaseSpeed.ToString("F1");
        maxSpeed.text = playerData.playerMaxSpeed.ToString("F1");
        turningSpeed.text = playerData.playerTurningSpeed.ToString("F1");
        attackSpeed.text = bulletData.linerBulletCoolDownTime.ToString("F1");
        attackDistance.text = bulletData.linerBulletExistenceTime.ToString("F1");
    }

    void iumi()
    {
        
    }

}
