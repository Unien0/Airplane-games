using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData_SO", menuName = "Data/Enemy")]
public class EnemyData_SO : ScriptableObject
{
    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField]
    int maxHealth;
    public int MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField]
    int damage;
    public int Damage { get => damage; private set => damage = value; }
}
