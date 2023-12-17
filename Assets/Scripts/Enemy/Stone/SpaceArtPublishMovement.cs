using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceArtPublishMovement : MonoBehaviour
{
    private float stoneSpeed;
    private float turningSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        stoneSpeed = Random.Range(0.2f, 3f);
        turningSpeed = Random.Range(5, 30);
        MoveInRandomDirection(randomDirection);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * -turningSpeed * Time.deltaTime);
    }
    void MoveInRandomDirection(Vector2 direction)
    {
        // 使用Translate方法来移动物体
        transform.Translate(direction * stoneSpeed * Time.deltaTime);
    }
}
