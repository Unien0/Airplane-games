using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    [ReadOnly]
    protected string guid = System.Guid.NewGuid().ToString();//随机生成一个指定ID代码，自动生成

    //protected string filename
    //{
    //    get { return "SaveFile" + SaveSlot.slot + ".es3"; }
    //}

    public virtual void Awake()
    {
        transform.localPosition = ES3.Load<Vector3>(guid, transform.localPosition);

    }

    public virtual void OnDestroy()
    {
        ES3.Save<Vector3>(guid, transform.localPosition);
    }

}
