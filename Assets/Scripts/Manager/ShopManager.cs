using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ShopManager : MonoBehaviour
{
    [Title("SO引用")]
    public PlayerData_SO playerData;
    public PlayerBullet_SO bulletData;
    public ShopData_SO shopData;

    [HideInInspector]
    public void LevelUpChecker(int code)
    {
        // 找到对应商店类型的数据
        ShopData_SO.ShopDetails shopDetails = shopData.ShopDetailsList.Find(x => x.itemCode == code);

        if (shopDetails != null)
        {
            // 使用商店类型的数据进行升级判定
            if (playerData.playerMoney >= shopDetails.experienceCap)
            {
                shopDetails.level++;
                playerData.playerMoney -= shopDetails.experienceCap;

                int experienceCapIncrease = 0;
                foreach (ShopData_SO.ShopDetails.LevelRange range in shopDetails.levelRanges)
                {
                    if (shopDetails.level >= range.startLevel && shopDetails.level <= range.endLevel)
                    {
                        experienceCapIncrease = range.experienceCapIncrease;
                        break;
                    }
                }
                shopDetails.experienceCap += experienceCapIncrease;
                // 可以在这里添加其他的逻辑，例如更新 UI 或者触发升级事件
            }
        }
    }
}
