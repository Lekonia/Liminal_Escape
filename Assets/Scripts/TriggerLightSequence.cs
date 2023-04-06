using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLightSequence : MonoBehaviour
{
    [SerializeField] private Light[] lightsToTrigger;
    [SerializeField] private float timeBetweenLights;

    private int currentLightIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TriggerLights());
        }
    }

    private IEnumerator TriggerLights()
    {
        while (currentLightIndex < lightsToTrigger.Length)
        {
            lightsToTrigger[currentLightIndex].enabled = true;
            yield return new WaitForSeconds(timeBetweenLights);
            lightsToTrigger[currentLightIndex].enabled = false;
            currentLightIndex++;
        }

        currentLightIndex = 0; 
    }
}
