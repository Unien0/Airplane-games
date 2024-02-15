using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMissile : MonoBehaviour
{
    [Header("追踪导弹")]
    public PlayerBullet_SO bulletData;

    [SerializeField]
    [ReadOnly]
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
        float bulletCD = bulletData.TMbulletCDMultipler * bulletData.linerBulletCoolDownTime;
        if (time >= bulletCD)
        {
            time -= bulletCD;
            FindObjectOfType<BulletPool>().GetExplosion(this.transform.position, this.transform.rotation);
            EventHandler.CallPlaySoundEvent(SoundName.Shot1);
        }
    }
}
