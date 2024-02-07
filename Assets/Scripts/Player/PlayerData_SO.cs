using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "PlayerData_SO", menuName = "Data/Player")]
public class PlayerData_SO : ScriptableObject
{
    [Title("玩家ID与名称")]
    [BoxGroup("基本资料")]
    public int PlayerID;
    [BoxGroup("基本资料")]
    public string playerName;//名称

    public Sprite playerIcon;//图标

    public Sprite playerOnWorldSprite;//游戏内画像
    [LabelWidth(100)]
    [TextArea] public string playerDescription;//介绍
    [Header("持有金")]
    public int playerMoney;
    [Space(10)]

    [Header("玩家属性")]
    public int playerMaxHP;//最大血量
    public int playerMaxHPLevel;
    public List<playerVolumeLevelRange> hpLevel;

    public int playerHP;//当前血量
    public int playerLucky;
    [Header("_移动速度相关")]
    public float playerBaseSpeed;//基础速度
    public int playerBaseSpeedLevel;
    public List<playerVolumeLevelRange> baseSpeedLevel;

    public float playerMaxSpeed;//最大移速
    public int playerMaxSpeedLevel;
    public List<playerVolumeLevelRange> maxSpeedLevel;
    public float playerMinSpeed;//最小移速
    public float playerCurrentSpeed;//当前速度
    public float playerTurningSpeed;//转弯速度
    public int playerTurningSpeedLevel;
    public List<playerVolumeLevelRange> turningSpeedLevel;
    public float playerAcceleration;//加速度
    public float playerDeceleration;//减速度
    public float playerReverseDecelerationMultiplier;//反向减速系数
     [Space(10)]

    [Header("独立开关")]
    public bool isDead;//是否死亡
    public bool moveable;//是否可以移动
    public bool controllable;//是否可以控制

}
[System.Serializable]
public class playerVolumeLevelRange
{
    [FoldoutGroup("$Level", expanded: true)]
    public int Level;//对应等级
    [FoldoutGroup("$Level", expanded: true)]
    public int levelIncrease;//等级成长值
}
