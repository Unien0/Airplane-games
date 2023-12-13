using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpaceArtPublishParticleEffect : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    private float time;
    System.Action<SpaceArtPublishParticleEffect> deactivateAction;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            time -= 3;
            deactivateAction.Invoke(this);
        }
    }
    public void SetDeactivateAction(System.Action<SpaceArtPublishParticleEffect> deactivateAction)
    {
        this.deactivateAction = deactivateAction;
    }
}
