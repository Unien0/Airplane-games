using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData_SO", menuName = "Data/Enemy")]
public class EnemyData_SO : ScriptableObject
{
    public float moveSpeed;

    public int maxHealth;

    public int damage;
}
