using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowCamera : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin noiseProfile;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noiseProfile = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    /// <summary>
    /// 摄像机振动
    /// </summary>
    /// <param name="duration">持续时间</param>
    /// <param name="amplitude">幅度</param>
    /// <param name="frequency">频率</param>
    public void ShakeCamera(float duration = 0.25f, float amplitude = 2, float frequency = 1)
    {
        if (noiseProfile != null)
        {
            noiseProfile.m_AmplitudeGain = amplitude;
            noiseProfile.m_FrequencyGain = frequency;
            Invoke(nameof(StopShaking), duration);
        }
    }

    private void StopShaking()
    {
        if (noiseProfile != null)
        {
            noiseProfile.m_AmplitudeGain = 0;
            noiseProfile.m_FrequencyGain = 0;
        }
    }
}
