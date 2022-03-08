using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // interact types, door, bridge, light, break, spawn
    public bool interactTypeIsHold = true;

    [Header("Whisp Only")]
    [HideInInspector]
    public bool isInteractingWithWhisp = false;

    void Awake()
    {
        if(gameObject.tag == "PressurePlate")
        {
            interactTypeIsHold = true;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //pressure plate
        if (gameObject.tag == "PressurePlate" && collider.tag == "Player" || collider.tag == "Whisp")
        {
            Debug.Log("interacted with anything");
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        //whisp only
        else if (isInteractingWithWhisp && collider.tag == "Whisp" && gameObject.tag == "WhispOnlyInteractable")
        {
            Debug.Log("interacted with whisp");
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if(interactTypeIsHold)
        {
            //pressure plate
            if (gameObject.tag == "PressurePlate" && collider.tag == "Player" || collider.tag == "Whisp")
            {
                Debug.Log("uninteracted with anything");

                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            //whisp only
            if (interactTypeIsHold && isInteractingWithWhisp && collider.tag == "Whisp" && gameObject.tag == "WhispOnlyInteractable")
            {
                Debug.Log("uninteracted with whisp");
                isInteractingWithWhisp = false;
            }
        }
    }
}