using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NewPlayerController : MonoBehaviour
{
    public CurrentTask_SO currentTask;
    public Flowchart flowchart;
    public InGameController gameController;

    private void Start()
    {
        gameController.stop = true;
    }

    void Update()
    {
        Explanationed();
    }
    public void Explanationed()
    {
        if (flowchart.GetBooleanVariable("explanationed"))
        {
            gameController.stop = false;
        }
    }
}
