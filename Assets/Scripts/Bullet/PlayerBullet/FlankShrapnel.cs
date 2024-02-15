using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlankShrapnel : MonoBehaviour
{
    [Header("侧翼散弹")]
    public PlayerBullet_SO bulletData;

    [SerializeField]
    [ReadOnly]
    private float time;
    private Transform player;

    public Transform[] firePoint;

    private void Start()
    {
        player = GetComponent<Transform>();
    }

    void Update()
    {
        //FollowParentRotation();
        time += Time.deltaTime;
        if (time >= bulletData.FSBulletCoolDownTime)
        {
            time -= bulletData.FSBulletCoolDownTime;
            FindObjectOfType<BulletPool>().GetExplosion(this.transform.position, this.transform.rotation);
            EventHandler.CallPlaySoundEvent(SoundName.Shot1);
        }
    }
}
