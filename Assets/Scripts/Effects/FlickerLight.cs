using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    [SerializeField] private Light lightToFlicker;
    [SerializeField] private float intensityScale = 1f;
    [SerializeField] private float frequencyScale = 1f;
    [SerializeField] private float timeScale = 1f;

    private float baseIntensity;

    private void Start()
    {
        baseIntensity = lightToFlicker.intensity;
    }

    private void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * timeScale * frequencyScale, 0f);
        float flicker = Mathf.Lerp(baseIntensity, baseIntensity * intensityScale, noise);
        lightToFlicker.intensity = flicker;
    }
}
