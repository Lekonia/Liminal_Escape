using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    [SerializeField] private Light lightToFlicker;
    [SerializeField] private float minIntensity;
    [SerializeField] private float maxIntensity;
    [SerializeField] private float flickerSpeed;

    private float targetIntensity;

    private void Start()
    {
        targetIntensity = lightToFlicker.intensity;
    }

    private void Update()
    {
        targetIntensity = Random.Range(minIntensity, maxIntensity);
        lightToFlicker.intensity = Mathf.Lerp(lightToFlicker.intensity, targetIntensity, Time.deltaTime * flickerSpeed);

        //lightToFlicker.intensity = Mathf.Lerp(lightToFlicker.intensity, targetIntensity, Time.deltaTime * flickerSpeed);

        //if (Mathf.Approximately(lightToFlicker.intensity, targetIntensity))
        //{
        //    targetIntensity = Random.Range(minIntensity, maxIntensity);
        //}
    }
}
