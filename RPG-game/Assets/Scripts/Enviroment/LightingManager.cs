using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] Light directionalLight;
    [SerializeField] LightingPreset preset;
    [SerializeField, Range(0, 24)] float timeOfDay;

    void Update()
    {
        if(preset == null) return;

        if(Application.isPlaying)
        {
            timeOfDay += Time.deltaTime / 60;
            timeOfDay %= 24;
            UpdateLighting(timeOfDay / 24);
        }
        else
        {
            UpdateLighting(timeOfDay / 24);
        }
    }

    void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);

        if(directionalLight != null)
        {
            directionalLight.color = preset.directionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f)-90f, 170f, 0));
        }
    }
}
