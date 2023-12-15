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
        //ÕâÀEòÎªÃ»ÓĞÅö×²Ìå£¬ËùÒÔÍ¨¹ıÁ½¸ö°´¼üA£¬BÄ£ÄâµĞÈËËÀÍö´¥·¢
        //Éè¶¨Ò»¸ö¶¨ÒåµĞÈËÎ»ÖÃµÄÃ¶¾ÙĞÍ£¬²»Í¬µÄÎ»ÖÃ¶ÔÓ¦²»Í¬µÄÏûÃğ°´¼E
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
            //µ÷ÓÃ±¬Õ¨ÀàµÄ¶ÔÏó³ØÖĞÉè¶¨µÄ»ñÈ¡·½·¨£¬´«ÈE±Ç°µĞÈËµÄÎ»ÖÃ£¬ÊµÏÖµĞÈËºÍÌØĞ§µÄÒ»Ò»¶ÔÓ¦
            FindObjectOfType<ExplosionPool>().GetExplosion(this.transform.position);
            isDead = false;
        }
    }
}
