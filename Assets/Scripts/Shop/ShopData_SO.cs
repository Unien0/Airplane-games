using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "ShopData_SO", menuName = "Data/Shop")]
[InlineEditor]
public class ShopData_SO : ScriptableObject
{
    [Title("商店列表")]
    public List<ShopDetails> ShopDetailsList;

    [System.Serializable]
    public class ShopDetails
    {
        [FoldoutGroup("$shopType", expanded: true)]
        public int itemCode;
        [FoldoutGroup("$shopType", expanded: true)]
        public string shopName;
        [FoldoutGroup("$shopType", expanded: true)]
        public ShopType shopType;
        [FoldoutGroup("$shopType", expanded: true)]
        [LabelWidth(100)]
        [TextArea]
        public string shopDescription;//商店简介
        [FoldoutGroup("$shopType", expanded: true)]
        public Sprite shopImage;
        [FoldoutGroup("$shopType", expanded: true)]
        public int experience = 0;
        [FoldoutGroup("$shopType", expanded: true)]
        public int level = 1;
        [FoldoutGroup("$shopType", expanded: true)]
        public int experienceCap;
        [Title("等级范围内所需经验")]
        [FoldoutGroup("$shopType", expanded: true)]
        public List<LevelRange> levelRanges;//等级列表

        [System.Serializable]
        public class LevelRange
        {
            public int startLevel;//启动等级
            public int endLevel;//结束等级，在这一定区间内升级都需要同样的经验值
            public int experienceCapIncrease;//所需经验值（浮动项，根据当前等级改编）
        }
    }
}

public enum ShopType
{
    hp, damage, baseSpeed, maxSpeed, turningSpeed, coolDownTime, bulletExistenceTime
}
