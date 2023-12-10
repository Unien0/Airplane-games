using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData_SO playerData;

    #region SO数据获取
    //获取移速和转速
    public float playerBaseSpeed//基础速度
    {
        get { if (playerData != null) return playerData.playerBaseSpeed; else return 0; }
    }
    public float playerMaxSpeed//最大速度
    {
        get { if (playerData != null) return playerData.playerMaxSpeed; else return 0; }
    }
    public float playerMinSpeed//最小速度
    {
        get { if (playerData != null) return playerData.playerMinSpeed; else return 0; }
    }
    public float currentMoveSpeed//当前速度【可变】
    {
        get { if (playerData != null) return playerData.playerCurrentSpeed; else return 0; }
        set { playerData.playerCurrentSpeed = value; }
    }
    public float playerTurningSpeed//转弯速度
    {
        get { if (playerData != null) return playerData.playerTurningSpeed; else return 0; }
    }
    public float playerAcceleration//加速度
    {
        get { if (playerData != null) return playerData.playerAcceleration; else return 0; }
    }
    public float playerDeceleration//减速度
    {
        get { if (playerData != null) return playerData.playerDeceleration; else return 0; }
    }
    public float playerReverseDecelerationMultiplier//反向减速系数，增加后加快减速速度
    {
        get { if (playerData != null) return playerData.playerReverseDecelerationMultiplier; else return 0; }
    }
    public bool isDead
    {
        get { if (playerData != null) return playerData.isDead; else return true; }
    }

    #endregion

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isDead)
        {
            Move();
            Turnigng();
        }
    }

    /// <summary>
    /// 玩家移动
    /// </summary>
    void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0f)
        {
            //玩家按下W后会缓慢加速
            currentMoveSpeed = Mathf.Clamp(rb2D.velocity.magnitude + verticalInput * playerAcceleration * Time.deltaTime, playerBaseSpeed, playerMaxSpeed);
            rb2D.velocity = transform.up * currentMoveSpeed;
        }
        else if (verticalInput < 0f)
        {
            //玩家按下S后会加快减速
            currentMoveSpeed = Mathf.Max(rb2D.velocity.magnitude + verticalInput * playerDeceleration * playerReverseDecelerationMultiplier * Time.deltaTime, playerMinSpeed);
            rb2D.velocity = transform.up * currentMoveSpeed;
        }
        else
        {
            currentMoveSpeed = Mathf.Max(rb2D.velocity.magnitude - playerDeceleration * Time.deltaTime, playerBaseSpeed);
            rb2D.velocity = transform.up * currentMoveSpeed;
        }
    }

    /// <summary>
    /// 玩家在碰撞后减速
    /// </summary>
    /// <param name="decelerationMultiplier"></param>
    public void DecreaseSpeed(float decelerationMultiplier)
    {
        currentMoveSpeed *= (1 - decelerationMultiplier);
    }

    /// <summary>
    /// 玩家转向
    /// </summary>
    void Turnigng()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(Vector3.forward * -playerTurningSpeed * playerAcceleration * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.forward * -playerTurningSpeed * Time.deltaTime);
            }

        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(Vector3.forward * playerTurningSpeed * playerAcceleration * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.forward * playerTurningSpeed * Time.deltaTime);
            }
        }
    }

}
