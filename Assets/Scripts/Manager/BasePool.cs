using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BasePool<T> : MonoBehaviour where T :Component
{
    [SerializeField] protected T prefab;
    [SerializeField] int defaultSize = 100;
    [SerializeField] int maxSize = 1000;
    ObjectPool<T> pool;

    //对象池的三个数据，表示激活、空闲、总数
    public int ActiveCount => pool.CountActive;
    public int InactiveCount => pool.CountInactive;
    public int TotalCount => pool.CountAll;

    protected void Initialized(bool collectionCheck = true) =>
        pool = new ObjectPool<T>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck, defaultSize, maxSize);

    protected virtual T createFunc()
    {
        var obj = Instantiate(prefab, transform);
        return obj;
    }

    protected virtual void actionOnGet(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected virtual void actionOnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected virtual void actionOnDestroy(T obj)
    {
        Destroy(obj);
    }

    //变量获取
    public T Get() => pool.Get();

    public void Release(T obj)
    {
        pool.Release(obj);
    }
    public void Clear()
    {
        pool.Clear();
    }
}
