using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerBulletController : MonoBehaviour
{
    public float timeCD = 1f;
    private float time;

    private Transform player;

    private void Start()
    {
        player = GetComponent<Transform>();
    }

    void Update()
    {
        //FollowParentRotation();
        time += Time.deltaTime;
        if (time>=timeCD)
        {
            time -= timeCD;
            FindObjectOfType<BulletPool>().GetExplosion(this.transform.position,this.transform.rotation);
        }
    }

    //void FollowParentRotation()
    //{
    //    // 获取父物体的旋转角度
    //    Quaternion playerRotation = player.rotation;

    //    // 将父物体的旋转应用到子物体
    //    transform.rotation = playerRotation;
    //}
}
