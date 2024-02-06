using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System.Linq;

public class ShopManager : MonoBehaviour
{
    [Title("SO引用")]
    public PlayerData_SO playerData;
    public PlayerBullet_SO bulletData;
    public ShopData_SO shopData;
    [Title("商店页面显示")]
    //价格显示
    [FoldoutGroup("价格")]
    public TMP_Text HpPriceDisplay;
    [FoldoutGroup("价格")]
    public TMP_Text damagePriceDisplay;
    [FoldoutGroup("价格")]
    public TMP_Text baseSpeedPriceDisplay;
    [FoldoutGroup("价格")]
    public TMP_Text maxSpeedPriceDisplay;
    [FoldoutGroup("价格")]
    public TMP_Text turningSpeedPriceDisplay;
    [FoldoutGroup("价格")]
    public TMP_Text coolDownTimePriceDisplay;
    [FoldoutGroup("价格")]
    public TMP_Text bulletExistenceTimePriceDisplay;
    //当前数值
    [FoldoutGroup("当前数值")]
    public TMP_Text hpValue;
    [FoldoutGroup("当前数值")]
    public TMP_Text damageValue;
    [FoldoutGroup("当前数值")]
    public TMP_Text baseSpeedValue;
    [FoldoutGroup("当前数值")]
    public TMP_Text maxSpeedValue;
    [FoldoutGroup("当前数值")]
    public TMP_Text turningSpeedValue;
    [FoldoutGroup("当前数值")]
    public TMP_Text coolDownTimeValue;
    [FoldoutGroup("当前数值")]
    public TMP_Text bulletExistenceTimeValue;

    [Title("购买页面显示")]
    public TMP_Text commodityName;//商品名称
    public TMP_Text commodityType;
    public Image commodityImage;
    public TMP_Text commodityDescription;//商品说明
    public TMP_Text commodityPrice;//价格
    public TMP_Text commodityLevel;
    public TMP_Text commodityValue;//人物数值对应
    public TMP_Text purchasePrice;//购买价格

    private int currentCode;//当前编号

    private void Update()
    {
        StorePageDisplay();
    }

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
                commodityValue.text = playerData.playerMaxHP.ToString() + "wJ";
                break;
            case ShopType.damage:
                commodityValue.text = bulletData.playerBulletDamage.ToString()+"wJ";
                break;
            case ShopType.baseSpeed:
                commodityValue.text = playerData.playerBaseSpeed.ToString("F1")+"wkm/h";
                break;
            case ShopType.maxSpeed:
                commodityValue.text = playerData.playerMaxSpeed.ToString("F1") + "wkm/h";
                break;
            case ShopType.coolDownTime:
                commodityValue.text = bulletData.linerBulletCoolDownTime.ToString("F1") + "s/B";
                break;
            case ShopType.turningSpeed:
                commodityValue.text = playerData.playerTurningSpeed.ToString("F1") + "r/s";
                break;
            case ShopType.bulletExistenceTime:
                commodityValue.text = bulletData.linerBulletExistenceTime.ToString("F1") + "/s";
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

    /// <summary>
    /// 商店页面显示
    /// </summary>
    public void StorePageDisplay()
    {
        #region 价格同步显示
        var hpShopDetails = shopData.ShopDetailsList.FirstOrDefault(shop => shop.shopType == ShopType.hp);
        // 检查是否找到了ShopDetails
        if (hpShopDetails != null)
        {
            // 获取类型的经验值增加并显示在 TMP_Text 上
            HpPriceDisplay.text = "$" + hpShopDetails.experienceCap.ToString();
        }
        else
        {
            // 如果找不到ShopDetails，给出一个错误提示
            Debug.LogError("如果找不到ShopDetails");
        }

        var damageShopDetails = shopData.ShopDetailsList.FirstOrDefault(shop => shop.shopType == ShopType.damage);
        // 检查是否找到了ShopDetails
        if (damageShopDetails != null)
        {
            // 获取类型的经验值增加并显示在 TMP_Text 上
            damagePriceDisplay.text = "$" + damageShopDetails.experienceCap.ToString();
        }
        else
        {
            // 如果找不到ShopDetails，给出一个错误提示
            Debug.LogError("如果找不到ShopDetails");
        }

        var baseSpeedShopDetails = shopData.ShopDetailsList.FirstOrDefault(shop => shop.shopType == ShopType.baseSpeed);
        // 检查是否找到了ShopDetails
        if (baseSpeedShopDetails != null)
        {
            // 获取类型的经验值增加并显示在 TMP_Text 上
            baseSpeedPriceDisplay.text = "$" + baseSpeedShopDetails.experienceCap.ToString();
        }
        else
        {
            // 如果找不到ShopDetails，给出一个错误提示
            Debug.LogError("如果找不到ShopDetails");
        }

        var maxSpeedShopDetails = shopData.ShopDetailsList.FirstOrDefault(shop => shop.shopType == ShopType.maxSpeed);
        // 检查是否找到了ShopDetails
        if (maxSpeedShopDetails != null)
        {
            // 获取类型的经验值增加并显示在 TMP_Text 上
            maxSpeedPriceDisplay.text = "$" + maxSpeedShopDetails.experienceCap.ToString();
        }
        else
        {
            // 如果找不到ShopDetails，给出一个错误提示
            Debug.LogError("如果找不到ShopDetails");
        }

        var turningSpeedShopDetails = shopData.ShopDetailsList.FirstOrDefault(shop => shop.shopType == ShopType.turningSpeed);
        // 检查是否找到了ShopDetails
        if (turningSpeedShopDetails != null)
        {
            // 获取类型的经验值增加并显示在 TMP_Text 上
            turningSpeedPriceDisplay.text = "$" + turningSpeedShopDetails.experienceCap.ToString();
        }
        else
        {
            // 如果找不到ShopDetails，给出一个错误提示
            Debug.LogError("如果找不到ShopDetails");
        }

        var coolDownTimeShopDetails = shopData.ShopDetailsList.FirstOrDefault(shop => shop.shopType == ShopType.coolDownTime);
        // 检查是否找到了ShopDetails
        if (coolDownTimeShopDetails != null)
        {
            // 获取类型的经验值增加并显示在 TMP_Text 上
            coolDownTimePriceDisplay.text = "$" + coolDownTimeShopDetails.experienceCap.ToString();
        }
        else
        {
            // 如果找不到ShopDetails，给出一个错误提示
            Debug.LogError("如果找不到ShopDetails");
        }

        var bulletExistenceTimeShopDetails = shopData.ShopDetailsList.FirstOrDefault(shop => shop.shopType == ShopType.bulletExistenceTime);
        // 检查是否找到了ShopDetails
        if (bulletExistenceTimeShopDetails != null)
        {
            // 获取类型的经验值增加并显示在 TMP_Text 上
            bulletExistenceTimePriceDisplay.text = "$" + bulletExistenceTimeShopDetails.experienceCap.ToString();
        }
        else
        {
            // 如果找不到ShopDetails，给出一个错误提示
            Debug.LogError("如果找不到ShopDetails");
        }
        #endregion

        #region 数据显示
        hpValue.text = playerData.playerMaxHP.ToString();
        damageValue.text = bulletData.playerBulletDamage.ToString();
        baseSpeedValue.text = playerData.playerBaseSpeed.ToString("F1");
        maxSpeedValue.text = playerData.playerMaxSpeed.ToString("F1");
        turningSpeedValue.text = playerData.playerTurningSpeed.ToString("F1");
        coolDownTimeValue.text = bulletData.linerBulletCoolDownTime.ToString("F1");
        bulletExistenceTimeValue.text = bulletData.linerBulletExistenceTime.ToString("F1");
        #endregion
    }
}
