using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewExplosion : MonoBehaviour
{
    private float time;
    private float maxTime = 1.0f;

    private ExplosionPool parentPool;

    private void Start()
    {
        //获取存放自己的对象池
        parentPool = FindObjectOfType<ExplosionPool>();

    }
    private void OnEnable()
    {
        //每次被唤醒时重置计时器时间
        time = 0f;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= maxTime)
        {
            //到时间后将本物体回收
            //用委托的方法在创建时就定好回收时间也是可行的
            parentPool.ReleaseExplosion(this);
            time = 0f;
        }
    }
}
