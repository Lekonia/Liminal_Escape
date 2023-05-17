using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

/*
 * Please keep in mind, certain effects like this fog script may need to be adjusted
 * depending on the Render pipeline being used.
 */

public class FogController : MonoBehaviour
{
    [SerializeField] private float areaSize = 100f; // Adjust the size of the fog area
    [SerializeField] private float density = 0.1f; // Adjust the density of the fog
    [SerializeField] private Color fogColor = Color.gray; // Adjust the color of the fog
    [SerializeField, Range(0f, 1f)] private float fogOpacity = 0.5f; // Adjust the opacity of the fog

    private Volume volume;

    private void Start()
    {
        if (RenderPipelineManager.currentPipeline is HDRenderPipeline)
        {
            volume = gameObject.AddComponent<Volume>();

        }

        RenderSettings.fog = true;
        RenderSettings.fogColor = fogColor;
        RenderSettings.fogDensity = density;
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = 0f;
        RenderSettings.fogEndDistance = areaSize;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(fogColor.r, fogColor.g, fogColor.b, fogOpacity);
        Gizmos.DrawCube(transform.position, new Vector3(areaSize, 1f, areaSize));
    }
}
