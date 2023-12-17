using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour
{
    public float rotationSpeed = 5f; // 旋转速度

    //引用
    private EnemyStats enemy;
    private Transform player;     // 玩家对象的引用

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        enemy = GetComponent<EnemyStats>();
    }

    void Update()
    {
        if (player != null && !enemy.isDead)
        {
            // 计算敌人朝向玩家的目标旋转
            Vector3 directionToPlayer = player.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToPlayer);

            // 使用插值平滑地过渡到目标旋转
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
