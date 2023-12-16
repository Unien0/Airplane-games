using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateXircle : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}