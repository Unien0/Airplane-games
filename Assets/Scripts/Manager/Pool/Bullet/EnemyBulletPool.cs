using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : BasePool<EnemyBullet>
{
    private PlayerState playerState;

    void Awake()
    {
        Initialized();
    }

    private void Start()
    {

    }

    public void GetExplosion()
    {
        Get();
        //temp.transform.position = pos;
        //temp.transform.rotation = rotation;
    }

    public void ReleaseExplosion(EnemyBullet obj)
    {
        Release(obj);
    }

}
