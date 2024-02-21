using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NewPlayerController : MonoBehaviour
{
    public SwitchData_SO switchData;
    public CurrentTask_SO currentTask;
    public Flowchart flowchart;
    public InGameController gameController;
    private bool endChat;

    private void Awake()
    {
        EventCenter.AddListener(EventType.NewPlayer, Switch);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventType.NewPlayer, Switch);

    }

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
        if (flowchart.GetBooleanVariable("explanationed") && !endChat)
        {
            gameController.stop = false;
            endChat = true;
        }
    }

    void Switch()
    {
        switchData.newbieTaskClear = true;
    }
}
