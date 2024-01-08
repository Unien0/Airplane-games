#define TMP
using UnityEngine;
using UnityEngine.UI;
#if TMP
using TMPro;
#endif

public class bl_FramesPerSecondsPro : MonoBehaviour
{
    [SerializeField]
    private Text FPSText = null;
#if TMP
    [SerializeField]private TextMeshProUGUI FPSTextTMP = null;
#endif
    float deltaTime = 0.0f;

    void Update()
    {
#if TMP
        if (FPSText == null && FPSTextTMP == null)
            return;
#else
        if (FPSText == null)
            return;
#endif

        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} FPS)", msec, fps);
      if(FPSText != null)  FPSText.text = text.ToUpper();
#if TMP
        if (FPSTextTMP != null) FPSTextTMP.text = text.ToUpper();
#endif
    }

    public void SetActive(bool active) => gameObject.SetActive(active);

    private static bl_FramesPerSecondsPro _instance;
    public static bl_FramesPerSecondsPro Instance
    {
        get
        {
            if (_instance == null) { _instance = FindObjectOfType<bl_FramesPerSecondsPro>(); }
            return _instance;
        }
    }
}