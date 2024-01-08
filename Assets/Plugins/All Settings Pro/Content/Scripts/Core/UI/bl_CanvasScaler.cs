using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bl_CanvasScaler : MonoBehaviour
{
    private CanvasScaler canvasScaler;
    private Vector2 defaultResolution;

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        if (canvasScaler == null) return;
        defaultResolution = canvasScaler.referenceResolution;
    }

    public void ScaleTo(float multiplier)
    {
        if (canvasScaler == null) return;

        Vector2 rr = defaultResolution;
        rr = rr * multiplier;
        canvasScaler.referenceResolution = rr;
    }
}