using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_Extender : MonoBehaviour
{
    public GameObject objectToDuplicate;
    public float distanceForward;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Duplicate the object
            GameObject duplicatedObject = Instantiate(objectToDuplicate, transform.position + transform.forward * distanceForward, transform.rotation);

            // Move the duplicated object forward
            duplicatedObject.transform.Translate(Vector3.forward * distanceForward, Space.Self);
        }
    }
}
