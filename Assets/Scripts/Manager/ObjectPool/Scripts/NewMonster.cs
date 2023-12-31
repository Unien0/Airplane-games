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
        //这纴E蛭挥信鲎蔡澹酝ü礁霭醇麬，B模拟敌人死亡触发
        //设定一个定义敌人位置的枚举型，不同的位置对应不同的消灭按紒E
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
            //调用爆炸类的对象池中设定的获取方法，传葋E鼻暗腥说奈恢茫迪值腥撕吞匦У囊灰欢杂�
            FindObjectOfType<ExplosionPool>().GetExplosion(this.transform.position);
            isDead = false;
        }
    }
}
