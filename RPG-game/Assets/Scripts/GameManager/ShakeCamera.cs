using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float shakeIntensity = 1;
    public float shakeTime = .2f;

    float timer;
    CinemachineBasicMultiChannelPerlin _cbmcp;

    public static bool shake;

    void Start()
    {
        StopShake();
    }

    void StartShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = shakeIntensity;

        timer = shakeTime;
    }

    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0;

        timer = 0;
    }

    void Update()
    {
        if(shake)
        {
            StartCoroutine(ShakeCameraCoroutine());   
        }
    }

    IEnumerator ShakeCameraCoroutine()
    {
        StartShake();
        yield return new WaitForSeconds(shakeTime);
        shake=false;
        StopShake();
    }
}
