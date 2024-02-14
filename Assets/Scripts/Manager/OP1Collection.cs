using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class OP1Collection : MonoBehaviour
{
    public SwitchData_SO switchData;
    public Flowchart flowchart;

    public Button plan1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("OneTask"))
        {
            plan1.interactable = true;
        }
        else
        {
            plan1.interactable = false;
        }
    }
}
