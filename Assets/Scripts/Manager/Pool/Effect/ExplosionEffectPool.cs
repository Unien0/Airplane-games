using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffectPool : BasePool<AnimationEvent>
{
    void Awake()
    {
        Initialized();
    }

    public void GetExplosion(Vector3 pos)
    {
        var temp = Get();
        temp.transform.position = pos;
    }

    public void ReleaseExplosion(AnimationEvent obj)
    {
        Release(obj);
    }
}
