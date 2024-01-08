#define TMP
using UnityEngine;
using UnityEngine.UI;
#if TMP
using TMPro;
#endif

public class bl_KeyInfoUI : MonoBehaviour
{
    [SerializeField] private Text FunctionText = null;
    [SerializeField] private Text KeyText = null;
#if TMP
    [SerializeField] private TextMeshProUGUI FunctionTextTMP = null;
    [SerializeField] private TextMeshProUGUI KeyTextTMP = null;
#endif

    private bl_KeyInfo cacheInfo;
    private bl_KeyOptionsUI KeyOptions;

    public void Init(bl_KeyInfo info, bl_KeyOptionsUI koui)
    {
        cacheInfo = info;
        KeyOptions = koui;
        if (FunctionText != null) FunctionText.text = info.Description;
        if (KeyText != null) KeyText.text = info.Key.ToString();
#if TMP
        if (FunctionTextTMP != null) FunctionTextTMP.text = info.Description;
        if (KeyTextTMP != null) KeyTextTMP.text = info.Key.ToString();
#endif
    }

    public void SetKeyChange()
    {
        KeyOptions.SetWaitKeyProcess(cacheInfo);
    }

}