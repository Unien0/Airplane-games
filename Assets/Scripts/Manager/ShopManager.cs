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
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void LevelUpChecker(ShopType shopType)
    //{
    //    // 找到对应商店类型的数据
    //    ShopData_SO.ShopDetails shopDetails = shopData.ShopDetailsList.Find(x => x.shopType == shopType);

    //    if (shopDetails != null)
    //    {
    //        // 使用商店类型的数据进行升级判定
    //        if (shopDetails.experience >= shopDetails.experienceCap)
    //        {
    //            shopDetails.level++;
    //            shopDetails.experience -= shopDetails.experienceCap;

    //            int experienceCapIncrease = 0;
    //            foreach (ShopData_SO.levelRanges range in shopDetails.levelRanges)
    //            {
    //                if (shopDetails.level >= range.startLevel && shopDetails.level <= range.endLevel)
    //                {
    //                    experienceCapIncrease = range.experienceCapIncrease;
    //                    break;
    //                }
    //            }
    //            shopDetails.experienceCap += experienceCapIncrease;
    //            // 可以在这里添加其他的逻辑，例如更新 UI 或者触发升级事件
    //        }
    //    }
    //}
}
