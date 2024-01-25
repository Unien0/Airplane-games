using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    [Title("SO���p")]
    public PlayerData_SO playerData;
    [Title("TMP���{")]
    public TMP_Text money;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDataDisplay();
    }

    void PlayerDataDisplay()
    {
        money.text = "$"+playerData.playerMoney.ToString();
    }
}
