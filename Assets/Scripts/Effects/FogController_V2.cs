using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class FogController_V2 : MonoBehaviour
{
    [SerializeField] private float areaSize = 20f;
    [SerializeField] private Color fogColor = Color.gray;
    [SerializeField, Range(0f, 1f)] private float fogOpacity = 0.5f;

    private void Start()
    {
        VolumeProfile volumeprofile = GetComponent<Volume>()?.sharedProfile;
        if (volumeprofile == null)
        {
            Debug.LogError("FogController_V2 requires a Volume component with a VolumeProfile.");
            return;
        }

        // Remove existing fog if present
        volumeprofile.Remove<Fog>();

        // Create new fog
        Fog fog = volumeprofile.Add<Fog>();

        // Configure fog parameters
        fog.enabled.Override(true);
        fog.albedo.Override(fogColor);
        fog.meanFreePath.Override(0f);
        fog.maximumHeight.Override(areaSize);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(fogColor.r, fogColor.g, fogColor.b, fogOpacity);
        Gizmos.DrawCube(transform.position, new Vector3(areaSize, 1f, areaSize));
    }
}
