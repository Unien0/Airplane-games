using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceArtPublishState : MonoBehaviour
{
    public int stoneHP;
    
    public int baseDamage = 10;         // 基础伤害
    public float damageMultiplier = 1f; // 速度倍增因子
    public float playerDecelerationMultiplier = 0.5f;//玩家减速
    public bool isDead;

    private void Update()
    {
        Kill();
    }

    public void TakeDamage(int dmg)
    {
        stoneHP -= dmg;

        if (stoneHP <= 0)
        {
            gameObject.layer = 9;
            isDead = true;
            Kill();
        }
    }

    public void Kill()
    {

        //测试用脚本
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 pos = this.transform.position;
            EventCenter.Broadcast(EventType.SpaceArtPublishParticle, pos);
            //Destroy(this.gameObject);
        }
        //Vector3 pos = this.transform.position;
        //EventCenter.Broadcast(EventType.SpaceArtPublishParticle, pos);
        //Destroy(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 获取碰撞速度
            float collisionSpeed = collision.relativeVelocity.magnitude;

            // 计算伤害
            int damage = Mathf.RoundToInt(baseDamage + collisionSpeed * damageMultiplier);

            // 处理玩家伤害
            PlayerState playerHealth = collision.gameObject.GetComponent<PlayerState>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            // 减速玩家
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            // 减速玩家
            if (playerMovement != null)
            {
                playerMovement.DecreaseSpeed(playerDecelerationMultiplier);
            }
        }
    }
}
