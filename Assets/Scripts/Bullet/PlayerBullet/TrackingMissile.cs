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
    private float bulletCD;
    private void Start()
    {
        player = GetComponent<Transform>();
        bulletCD = bulletData.FSbulletCDMultipler * bulletData.linerBulletCoolDownTime;
    }

    void Update()
    {
        //FollowParentRotation();
        time += Time.deltaTime;
        if (time >= bulletCD)
        {
            time -= bulletCD;
            FindObjectOfType<TMBulletPool>().GetExplosion(this.transform.position, this.transform.rotation);
            EventHandler.CallPlaySoundEvent(SoundName.Shot1);
        }
    }
}
