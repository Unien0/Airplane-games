using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerBulletController : MonoBehaviour
{
    public PlayerBullet_SO bulletData;
    public float linerBulletCoolDownTime
    {
        get { if (bulletData != null) return bulletData.linerBulletCoolDownTime; else return 0; }
    }

    [SerializeField][ReadOnly]
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
        if (time>= linerBulletCoolDownTime)
        {
            time -= linerBulletCoolDownTime;
            FindObjectOfType<BulletPool>().GetExplosion(this.transform.position,this.transform.rotation);
        }
    }
}
