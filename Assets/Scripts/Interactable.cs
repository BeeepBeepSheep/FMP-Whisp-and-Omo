using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool isInteracting = false;
    public bool interactTypeIsHold = true;

    // interact types, door, bridge, light, break, spawn

    public void Interacted()
    {
        isInteracting = true;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(isInteracting && collider.tag == "Whisp")
        {
            Debug.Log("interacted");
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if(interactTypeIsHold && isInteracting && collider.tag == "Whisp")
        {
            Debug.Log("uninteracted");
            isInteracting = false;
        }
    }
}