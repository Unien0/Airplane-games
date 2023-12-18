using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceArtPublishMovement : MonoBehaviour
{
    [SerializeField]
    [ReadOnly]
    private float stoneSpeed;
    private float turningSpeed;
    private Rigidbody2D rb;
    Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerState>()?.transform;
        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        // 计算初始方向
        Vector2 playerDirection = (Vector2)player.position - (Vector2)transform.position;
        float initialAngle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;

        // 添加一个随机偏差角度
        float randomAngleOffset = Random.Range(-10f, 10f);
        float finalAngle = initialAngle + randomAngleOffset;

        // 计算初始方向并应用推力
        Vector2 initialDirection = new Vector2(Mathf.Cos(finalAngle * Mathf.Deg2Rad), Mathf.Sin(finalAngle * Mathf.Deg2Rad));
        stoneSpeed = Random.Range(20f, 300f);
        turningSpeed = Random.Range(5, 30);

        // 应用初始的推力和角速度
        rb.AddForce(initialDirection * stoneSpeed);
        rb.angularVelocity = turningSpeed;
    }
}
