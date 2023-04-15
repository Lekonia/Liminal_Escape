using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ColliderGizmoV2 : MonoBehaviour  //Editor //didnt quite work, but we will keep going
{
    // All this Gizmo stuff as a tool to see while editing works like a charm, i like it, no touchies!!
    public float radius = 1f;

    [SerializeField] BoxCollider boxCollider; // It Worked!! SerializeField you beauty! issues with no assignment or something, privatize it and see what happens... but don't!

    [SerializeField] bool showGizmo = true;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    void OnDrawGizmos()
    {
        if (showGizmo)
        {
            Gizmos.color = Color.yellow;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, boxCollider.size);
        }

        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Player"))
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, radius);
                break;
            }
        }
    }
}