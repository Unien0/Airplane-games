using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : BasePool<EnemyStats>
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

    public void ReleaseExplosion(EnemyStats obj)
    {
        Release(obj);
    }
}
