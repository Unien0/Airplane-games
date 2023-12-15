using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// �̳���BasePool��һ��ʵ�ֹ��ܵ��Ӷ����
/// �̳�ʱ�������滻Ϊĳһ�ض����ͣ���Ϊ�����Ͷ���Ķ���أ�����װ���ǹ����ڱ�ը��Ч�ϵ�NewExplosion��
/// </summary>
public class ExplosionPool : BasePool<NewExplosion>
{
    //��ͬ��ǰ�ᵽ�ģ���Ҫ��awake�����г�ʼ������pool
    void Awake()
    {
        Initialized();
    }

    //�������Ҫ�Ը����еķ��������޸ģ�����Ҫ��д
    //��֮����Ҫ�ڷ������м����µĴ�������޸��ϴ��룬��Ҫ��д��ʹ��override�ؼ��֣������ֺ͸��෽��һ����Ȩ��
    //��Ϊ���͵����룬���������T��obj����Ҫ��д�ͻ��Զ�ת��ΪNewExplosion��



    //�˷�����ר������ʵ���ƶ��ӳ��г���Ķ���������
    //ͨ�������趨�Ĺ�������Get�����õ�����Ķ��󣬲����ö��������ı����Ҫ������
    //��Ҫ��������Ϊ�βα����룬��֤ʵ���ȶ���һһ��Ӧ��ϵ����Ҳ�ǲ�ʹ�ù㲥����findobject�ȷ�����ԭ��
    public void GetExplosion(Vector3 pos)
    {
        var temp = Get();
        temp.transform.position = pos;
    }

    //�˷������ڽ������ͷŻس�
    //ʵ������һ��ͨ��ֱ�ӵ��û���� Release()����ʵ��Ч����һģһ���ģ�������Ϊ�ڶ�Ӧ�����ඨ�����ֿɶ���ǿ�ķ������ں����Ķ����뷨������ǿ��֢������������
    //�����ʵ�ھ��������ǲ��õģ����ҽ����㲻Ҫɾ�����ޣ����ǰ�Release()��Ȩ�޸�Ϊprotected�������ǲ��Ǿ��������
    public void ReleaseExplosion(NewExplosion obj)
    {
        Release(obj);
    }
}
