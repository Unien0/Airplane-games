using UnityEngine;

public class StoneSplashingPool : BasePool<SpaceArtPublishParticleEffect>
{
     void Awake()
    {
        Initialized();
    }
    //protected override SpaceArtPublishParticleEffect createFunc()
    //{
    //    var obj = base.createFunc();
    //    obj.SetDeactivateAction(delegate { Release(obj); });
    //    return obj;
    //}

    public void GetExplosion(Vector3 pos)
    {
        var temp = Get();
        temp.transform.position = pos;
    }

    public void ReleaseExplosion(SpaceArtPublishParticleEffect obj)
    {
        Release(obj);
    }
}
