using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGenerator : MonoBehaviour
{
    public GameObject chestPrefab;
    public float minRadius = 500f;
    public float maxRadius = 1000f;

    void Start()
    {
        GenerateChest();
    }

    void GenerateChest()
    {
        // 在半径范围内生成宝箱
        float radius = Random.Range(minRadius, maxRadius);
        float angle = Random.Range(0f, 360f);

        // 将极坐标转换为笛卡尔坐标
        float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

        Vector3 chestPosition = new Vector3(x, y, 0f); // 在2D平面上，z坐标通常为0

        // 生成宝箱
        Instantiate(chestPrefab, chestPosition, Quaternion.identity);
    }
}
