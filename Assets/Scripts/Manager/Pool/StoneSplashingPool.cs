using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class StoneSplashingPool : MonoBehaviour
{
    public GameObject Effect;
    public int BasicQuantity = 10;
    public int MaxQuantity = 1000;

    ObjectPool<GameObject> pool;
    private void Awake()
    {
        pool = new ObjectPool<GameObject>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, true, BasicQuantity, MaxQuantity);

        EventCenter.AddListener<Vector3>(EventType.SpaceArtPublishParticle, GetObject);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<Vector3>(EventType.SpaceArtPublishParticle, GetObject);
    }

    private GameObject createFunc()
    {
        var obj = Instantiate(Effect, transform);
        obj.GetComponent<SpaceArtPublishParticleEffect>().pool = pool;
        return obj;
    }

    private void actionOnGet(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void actionOnRelease(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void actionOnDestroy(GameObject obj)
    {
        Destroy(obj);
    }

    void GetObject(Vector3 position)
    {
        var effect = pool.Get();
        effect.transform.position = position;
    }

}
