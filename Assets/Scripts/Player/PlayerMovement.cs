using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData_SO playerData;

    #region SO数据获取
    //获取移速和转速
    public float currentMoveSpeed
    {
        get { if (playerData != null) return playerData.playerCurrentSpeed; else return 0; }
    }
    public float playerTurningSpeed
    {
        get { if (playerData != null) return playerData.playerTurningSpeed; else return 0; }
    }
    public float playerAcceleration
    {
        get { if (playerData != null) return playerData.playerAcceleration; else return 0; }
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

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb2D.velocity = transform.up * currentMoveSpeed * playerAcceleration;
        }
        else
        {
            rb2D.velocity = transform.up * currentMoveSpeed;
        }
    }

    void Turnigng()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.right * -playerTurningSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.right * playerTurningSpeed * Time.deltaTime);
        }
    }

}
