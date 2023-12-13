using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpaceArtPublishParticleEffect : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    private float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 5)
        {
            time -= 5;
            pool.Release(gameObject);
        }
    }
}
