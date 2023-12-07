﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData_SO", menuName = "Player/PlayerDetails")]
public class PlayerData_SO : ScriptableObject
{
    [Header("PlayerData")]
    [Header("基本资料")]
    public string playerName;//名前
    public Sprite playerIcon;//アイコン
    public Sprite playerOnWorldSprite;//Game内の画像
    [Multiline] public string playerDescription;//プレイヤーキャラクターの紹介
    [Space(10)]
    [Header("玩家属性")]
    public int playerMaxHP;
    public int playerHP;
    public float playerSpeed;

}
