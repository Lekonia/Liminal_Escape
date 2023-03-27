using System.Collections;
using System.Collections.Generic;
// using UnityEditor; // not there yet
using UnityEngine;

//[CustomEditor(typeof(Collider))] // Not really working
[RequireComponent(typeof(BoxCollider))]
public class ColliderGizmo : MonoBehaviour  //Editor //didnt quite work, but we will keep going
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
            //Gizmos.DrawWireCube(transform.position, transform.localScale);
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

    /*
     * Ok, this whole gizmo collider got messy, and i will maybe clean it up once i get it right
     * but i might just leave it for me to learn from what not to do or how to improve it... we will see...
     * DISREGARD THIS! the above code works muuuuuuuuch bettererer, but not my unglish.
     */

    //private void OnSceneGui()
    //{
    //    Collider collider = target as Collider;
    //    if (collider == null) return;

    //    Handles.color = Color.yellow;
    //    Handles.DrawWireDisc(collider.transform.position, collider.transform.up, collider.bounds.extents.magnitude);
    //}
}
