using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psavesy : SaveSystem
{
    private TestPM testPM;

    public override void Awake()
    {
        //testPM = gameObject.GetComponent<TestPM>();
        //读取速度
        //testPM.MoveSpeed = ES3.Load<float>(guid, testPM.MoveSpeed);
        //transform.localPosition = ES3.Load<Vector3>(guid, transform.localPosition);
    }

    public override void OnDestroy()
    {
        //存储速度
        //ES3.Save<float>(guid, testPM.MoveSpeed);
        //ES3.Save<Vector3>(guid, transform.localPosition);
    }
}
