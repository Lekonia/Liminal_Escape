using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToToggle;
    [SerializeField] private bool isActive;

    private void Start()
    {
        objectToToggle.SetActive(isActive);
    }

    private void Toggle()
    {
        isActive = !isActive;
        objectToToggle.SetActive(isActive);
    }
}
