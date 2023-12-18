using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceArtPublishParticleEffect : MonoBehaviour
{
    private float time;
    //System.Action<SpaceArtPublishParticleEffect> deactivateAction;
    private StoneSplashingPool parentPool;

    private void OnEnable()
    {
        time = 0f;
    }

    private void Start()
    {
        parentPool = FindObjectOfType<StoneSplashingPool>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            time -= 3;
            parentPool.ReleaseExplosion(this);
            //deactivateAction.Invoke(this);
        }
    }
    //public void SetDeactivateAction(System.Action<SpaceArtPublishParticleEffect> deactivateAction)
    //{
    //    this.deactivateAction = deactivateAction;
    //}
}
