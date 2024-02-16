using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerBullet_SO", menuName = "Data/Bullet/PlayerBullet")]
public class PlayerBullet_SO : ScriptableObject
{
    [Header("子弹资料")]
    [Header("基础属性")]
    [Header("_伤害")]
    public int playerBulletDamage;//基础力量
    public int playerBulletDamageLevel;
    public List<playerVolumeLevelRange> bulletDamageLevel;
    [Header("_伤害倍率")]
    public float linerBulletDamageMultipler;//子弹倍率
    public float FSBulletDamageMultipler;//子弹倍率
    public float TMBulletDamageMultipler;//子弹倍率
    [Header("_子弹冷却时间")]
    public float linerBulletCoolDownTime;//基础
    public int linerBulletCoolDownTimeLevel;
    public List<playerVolumeLevelRange> coolDownTimeLevel;
    public float FSbulletCDMultipler;//子弹冷却倍率
    public float TMbulletCDMultipler;//子弹冷却倍率
    [Header("_存在时间")]
    public float linerBulletExistenceTime;//存在时间
    public int linerBulletExistenceTimeLevel;
    public List<playerVolumeLevelRange> bulletExistenceTimeLevel;
    public float FSbulletETMultipler;//子弹时间倍率
    public float TMbulletETMultipler;//子弹时间倍率
    [Header("_存在距离")]
    public float linerBulletExistenceDistance;
    [Header("_速度")]
    public float linerBulletSpeed;//基础
    public float FSBulletSpeed;//基础
    public float TMBulletSpeed;//基础
    [Header("_穿透")]
    public int linerBulletPenetrationCount;//穿透次数
    public int FSBulletPenetrationCount;//穿透次数
    public int TMBulletPenetrationCount;//穿透次数

    [Header("追踪子弹属性")]
    public float trackingRange = 10f; // 定义追踪范围的默认值

    public bool FSWeapenOn;
    public bool TMWeapenOn;

}
