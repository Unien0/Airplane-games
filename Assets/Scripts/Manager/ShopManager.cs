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

    [Title("商店内显示")]
    public TMP_Text commodityName;//商品名称
    public TMP_Text commodityType;
    public Image commodityImage;
    public TMP_Text commodityDescription;//商品说明
    public TMP_Text commodityPrice;//价格
    public TMP_Text commodityLevel;
    public TMP_Text commodityValue;//人物数值对应
    public TMP_Text purchasePrice;//购买价格

    private int currentCode;//当前编号

    /// <summary>
    /// 按键升级
    /// </summary>
    /// <param name="code"></param>
    public void LevelUpChecker()
    {
        int code = currentCode;

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

            OpenStorePage(currentCode);
        }
    }

    /// <summary>
    /// 打开商店页面和升级时，刷新数据
    /// </summary>
    /// <param name="code"></param>
    public void OpenStorePage(int code)
    {
        currentCode = code;
        //先找到对应ID
        ShopData_SO.ShopDetails shopDetails = shopData.ShopDetailsList.Find(x => x.itemCode == code);
        //在找到对应ID的情况下根据ID进行显示
        if (shopDetails != null)
        {
            // 将商品信息显示在UI上
            commodityName.text = shopDetails.shopName;
            commodityType.text = shopDetails.shopType.ToString();
            commodityDescription.text = shopDetails.shopDescription;
            commodityImage.sprite = shopDetails.shopImage;
            commodityPrice.text = shopDetails.experienceCap.ToString();
            purchasePrice.text = shopDetails.experienceCap.ToString();
            commodityLevel.text =shopDetails.level.ToString();
            // 显示商品对应的玩家数值
            UpdateCommodityValue(shopDetails);
        }
    }

    private void UpdateCommodityValue(ShopData_SO.ShopDetails shopDetails)
    {
        // 根据商品类型更新商品对应的玩家数值
        switch (shopDetails.shopType)
        {
            case ShopType.hp:
                commodityValue.text = playerData.playerMaxHP.ToString();
                break;
            case ShopType.damage:
                commodityValue.text = bulletData.playerBulletDamage.ToString();
                break;
            case ShopType.baseSpeed:
                commodityValue.text = playerData.playerBaseSpeed.ToString();
                break;
            case ShopType.maxSpeed:
                commodityValue.text = playerData.playerMaxSpeed.ToString();
                break;
            case ShopType.coolDownTime:
                commodityValue.text = bulletData.linerBulletCoolDownTime.ToString();
                break;
            case ShopType.turningSpeed:
                commodityValue.text = playerData.playerTurningSpeed.ToString();
                break;
            case ShopType.bulletExistenceTime:
                commodityValue.text = bulletData.linerBulletExistenceTime.ToString();
                break;
        }
    }

    /// <summary>
    /// 处理购买按钮点击事件
    /// </summary>
    public void OnPurchaseButtonClick()
    {
        LevelUpChecker();
    }

}
