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
        //��ȡ����Լ��Ķ����
        parentPool = FindObjectOfType<ExplosionPool>();

    }
    private void OnEnable()
    {
        //ÿ�α�����ʱ���ü�ʱ��ʱ��
        time = 0f;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= maxTime)
        {
            //��ʱ��󽫱��������
            //��ί�еķ����ڴ���ʱ�Ͷ��û���ʱ��Ҳ�ǿ��е�
            parentPool.ReleaseExplosion(this);
            time = 0f;
        }
    }
}
