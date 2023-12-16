using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : BasePool<LinearBullet>
{
    private PlayerState playerState;

    void Awake()
    {
        Initialized();
    }

    private void Start()
    {
        
    }

    public void GetExplosion(Vector3 pos, Quaternion rotation)
    {
        var temp = Get();
        temp.transform.position = pos;
        temp.transform.rotation = rotation;
    }

    public void ReleaseExplosion(LinearBullet obj)
    {
        Release(obj);
    }

}
