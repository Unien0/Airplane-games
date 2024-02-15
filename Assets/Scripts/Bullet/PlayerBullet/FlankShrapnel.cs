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
        float bulletCD = bulletData.FSbulletCDMultipler * bulletData.linerBulletCoolDownTime;
        if (time >= bulletCD)
        {
            for (int i = 0; i < firePoint.Length; i++)
            {
                FindObjectOfType<BulletPool>().GetExplosion(this.transform.position, this.transform.rotation);
            }
            time -= bulletCD;
            EventHandler.CallPlaySoundEvent(SoundName.Shot1);
        }
    }
}
