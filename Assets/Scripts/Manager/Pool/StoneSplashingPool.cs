using UnityEngine;

public class StoneSplashingPool : BasePool<SpaceArtPublishParticleEffect>
{
     void Awake()
    {
        Initialized();
        EventCenter.AddListener<Vector3>(EventType.SpaceArtPublishParticle, GetObject);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<Vector3>(EventType.SpaceArtPublishParticle, GetObject);
    }

    protected override SpaceArtPublishParticleEffect createFunc()
    {
        var obj = base.createFunc();
        obj.SetDeactivateAction(delegate { Release(obj); });
        return obj;
    }

    void GetObject(Vector3 position)
    {
        //获取到对象池的对象
        Get();
        //将对象放置到指定位置
        gameObject.transform.position = position;
    }

}
