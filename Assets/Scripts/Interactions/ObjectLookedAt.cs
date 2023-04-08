using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookedAt : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float maxRayCastDistance = 10f;
    [SerializeField] private Material lookedAtMaterial;
    [SerializeField] private Material notLookAtMaterial;
    [SerializeField] private Color lookedAtColor = Color.green;
    [SerializeField] private Color notLookedAtColor = Color.red;

    private Renderer objectRenderer;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(player.position, player.forward, out hit, maxRayCastDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                objectRenderer.material = lookedAtMaterial;
                objectRenderer.material.color = lookedAtColor;
            }

            else
            {
                objectRenderer.material = notLookAtMaterial;
                objectRenderer.material.color = notLookedAtColor;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRayCastDistance);
    }
}
