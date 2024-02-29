using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerBulletController : MonoBehaviour
{
    [Header("直线子弹")]
    public PlayerBullet_SO bulletData;
    public PlayerData_SO playerData;
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
        if (!playerData.isDead)
        {
            //FollowParentRotation();
            time += Time.deltaTime;
            if (time >= linerBulletCoolDownTime)
            {
                time -= linerBulletCoolDownTime;
                FindObjectOfType<BulletPool>().GetExplosion(this.transform.position, this.transform.rotation);
                EventHandler.CallPlaySoundEvent(SoundName.Shot1);
            }
        }
    }
}
