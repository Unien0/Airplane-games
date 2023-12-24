using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private ExplosionEffectPool parentPool;

    private void Start()
    {
        parentPool = FindObjectOfType<ExplosionEffectPool>();
    }

    public void AnimationEnd()
    {
        parentPool.ReleaseExplosion(this);
    }

}
