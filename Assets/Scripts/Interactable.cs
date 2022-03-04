using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool hasInteracted = false;

    public void Interacted()
    {
        hasInteracted = true;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(hasInteracted && collider.tag == "Whisp")
        {
            Debug.Log("interacted");
        }
    }
}
