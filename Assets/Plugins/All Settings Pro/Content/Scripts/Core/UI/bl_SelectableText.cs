#define TMP
using UnityEngine;
using UnityEngine.UI;
#if TMP
using TMPro;
#endif

public class bl_SelectableText : MonoBehaviour
{
    [SerializeField]private Color OnEnterColor = new Color(1,1,1,1);
    [SerializeField,Range(0.1f,3)]private float Duration = 1;

    private Text m_Text;
#if TMP
    private TextMeshProUGUI m_textTMP;
#endif
    private Button m_Button;
    private Color defaultColor;
    private ColorBlock defaultColorBlock;
    private ColorBlock OnSelectColorBlock;

    void Awake()
    {
        if (GetComponent<Text>() != null)
        {
            m_Text = GetComponent<Text>();
            defaultColor = m_Text.color;
        }
        if(GetComponent<Button>() != null)
        {
            m_Button = GetComponent<Button>();
            defaultColorBlock = m_Button.colors;
            OnSelectColorBlock = defaultColorBlock;
            OnSelectColorBlock.normalColor = OnEnterColor;
        }
#if TMP
        m_textTMP = GetComponent<TextMeshProUGUI>();
        if(m_textTMP != null)
        {
            defaultColor = m_textTMP.color;
        }
#endif
}

    public void OnEnter()
    {
        if (m_Text != null) { m_Text.CrossFadeColor(OnEnterColor, Duration, true, true); }
        if (m_Button != null) { m_Button.colors = OnSelectColorBlock; }
#if TMP
        if (m_textTMP != null) m_textTMP.CrossFadeColor(OnEnterColor, Duration, true, true);
#endif
    }
    public void OnExit()
    {
        if (m_Text != null) { m_Text.CrossFadeColor(defaultColor, Duration, true, true); }
        if (m_Button != null) { m_Button.colors = defaultColorBlock; }
#if TMP
        if (m_textTMP != null) m_textTMP.CrossFadeColor(defaultColor, Duration, true, true);
#endif
    }
}