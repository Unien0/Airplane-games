using UnityEngine;

public class bl_ShowExample_ASP : MonoBehaviour
{

    void Update()
    {
        if (bl_Input.GetKeyDown("Pause"))
        {
            bl_AllSettingsPro.Instance.ShowMenu();
        }        
    }
}