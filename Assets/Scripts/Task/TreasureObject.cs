using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventCenter.Broadcast(EventType.CollectTaskClear);
        }
    }
}
