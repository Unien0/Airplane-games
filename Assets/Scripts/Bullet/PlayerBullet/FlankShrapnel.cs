using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlankShrapnel : MonoBehaviour
{
    [Header("侧翼散弹")]
    public PlayerBullet_SO bulletData;
    public PlayerData_SO playerData;

    [SerializeField]
    [ReadOnly]
    private float time;
    private float bulletCD;
    private Transform player;

    public Transform[] firePoint;

    private void Start()
    {
        player = GetComponent<Transform>();
        bulletCD= bulletData.FSbulletCDMultipler * bulletData.linerBulletCoolDownTime;
    }

    void Update()
    {
        if (!playerData.isDead)
        {
            time += Time.deltaTime;
            if (time >= bulletCD)
            {
                for (int i = 0; i < firePoint.Length; i++)
                {
                    FindObjectOfType<FSBulletPool>().GetExplosion(firePoint[i].position, firePoint[i].rotation);
                }
                time -= bulletCD;
                EventHandler.CallPlaySoundEvent(SoundName.Shot1);
            }
        }
    }
}
