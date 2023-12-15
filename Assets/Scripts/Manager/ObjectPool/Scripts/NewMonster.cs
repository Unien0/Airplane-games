using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMonster : MonoBehaviour
{
    public bool isDead = false;

    private KeyCode key;
    public enum MonsterPos
    {
        POS1,
        POS2,
        END
    }

    [SerializeField]private MonsterPos myPos;
    private void Update()
    {
        //����E�Ϊû����ײ�壬����ͨ����������A��Bģ�������������
        //�趨һ���������λ�õ�ö���ͣ���ͬ��λ�ö�Ӧ��ͬ�����𰴼�E
        switch(myPos)
        {
            case MonsterPos.POS1:
                key = KeyCode.A;
                break;

            case MonsterPos.POS2:
                key = KeyCode.B;
                break;
        }

        if(Input.GetKeyDown(key))
        {
            isDead = true;
        }

        if(isDead)
        {
            //���ñ�ը��Ķ�������趨�Ļ�ȡ��������ȁE�ǰ���˵�λ�ã�ʵ�ֵ��˺���Ч��һһ��Ӧ
            FindObjectOfType<ExplosionPool>().GetExplosion(this.transform.position);
            isDead = false;
        }
    }
}
