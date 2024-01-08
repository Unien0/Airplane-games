#define TMP
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
#if TMP
using TMPro;
#endif

public class bl_AllSettingsPro : MonoBehaviour
{

    [Header("Panels")]
    [SerializeField] private GameObject[] Panels = null;
    [SerializeField] private Button[] PanelButtons = null;
    [SerializeField] private Animator PanelAnimator = null;

    [Header("Settings")]
    public bool AnimateHidePanel = true;
    public int StartWindow;

    [Header("References")]
    [SerializeField] private GameObject SettingsPanel = null;
    [SerializeField] private Animator ContentAnim = null;
    [SerializeField] private Text TitlePanelText = null;
#if TMP
    [SerializeField] private TextMeshProUGUI TitlePanelTextTMP = null;
#endif
    private bool Show = false;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        ChangeWindow(StartWindow, false);
        ChangeSelectionButton(PanelButtons[StartWindow]);
        SettingsPanel.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_id"></param>
    public void ChangeWindow(int _id)
    {
        PanelAnimator.Play("Change", 0, 0);
        StartCoroutine(WaitForSwichet(_id));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_id"></param>
    public void ChangeWindow(int _id, bool anim)
    {
        if (anim)
        {
            PanelAnimator.Play("Change", 0, 0);
        }
        StartCoroutine(WaitForSwichet(_id));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="b"></param>
    public void ChangeSelectionButton(Button b)
    {
        for (int i = 0; i < PanelButtons.Length; i++)
        {
            PanelButtons[i].interactable = true;
        }
        b.interactable = false;
    }

    /// <summary>
    /// 
    /// </summary>
    public void ShowMenu()
    {
        Show = !Show;
        if (Show)
        {
            StopCoroutine("HideAnimate");
            SettingsPanel.SetActive(true);
            ContentAnim.SetBool("Show", true);
        }
        else
        {
            if (AnimateHidePanel)
            {
                StartCoroutine("HideAnimate");
            }
            else
            {
                SettingsPanel.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetShadowEnable(int value)
    {
        ShadowQuality sq = (ShadowQuality)value;
        QualitySettings.shadows = sq;
    }

    public void UpdateHudScale(float value)
    {
        bl_CanvasScaler[] allcs = FindObjectsOfType<bl_CanvasScaler>();
        float v = 2 - value;
        foreach (var cs in allcs)
        {
            cs.ScaleTo(v);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_id"></param>
    /// <returns></returns>
    IEnumerator WaitForSwichet(int _id)
    {
        yield return StartCoroutine(WaitForRealSeconds(0.25f));
        for (int i = 0; i < Panels.Length; i++)
        {
            Panels[i].SetActive(false);
        }
        Panels[_id].SetActive(true);
        if (TitlePanelText != null)
        {
            TitlePanelText.text = Panels[_id].name.ToUpper();
        }
#if TMP
        if (TitlePanelTextTMP != null) TitlePanelTextTMP.text = Panels[_id].name.ToUpper();
#endif
    }

    public static IEnumerator WaitForRealSeconds(float time)
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator HideAnimate()
    {
        if (ContentAnim != null)
        {
            ContentAnim.SetBool("Show", false);
            yield return new WaitForSeconds(ContentAnim.GetCurrentAnimatorStateInfo(0).length);
            SettingsPanel.SetActive(false);
        }
        else
        {
            SettingsPanel.SetActive(false);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetFullscreen()
    {
        bl_AllSettings.Instance.ApplyResolution();
    }

    public void ApplyBrightness(float value) => bl_BrightnessImage.Instance?.SetValue(value);
    public void ApplyVolume(float value) => AudioListener.volume = value;

    /// <summary>
    /// Save all options for load in a next time
    /// </summary>
    public void SaveOptions()
    {
        bl_AllSettings.Instance.SaveSettings();
    }

    private static bl_AllSettingsPro _instance;
    public static bl_AllSettingsPro Instance
    {
        get
        {
            if(_instance == null) { _instance = FindObjectOfType<bl_AllSettingsPro>(); }
            return _instance;
        }
    }
}