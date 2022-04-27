using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProccessingManager : MonoBehaviour
{
    bool isInside = true;
    [SerializeField] private Animator postProccessAnim;

    void ToggleOutside()
    {
        if(isInside)
        {
            isInside = false;
        }
        else
        {
            isInside = true;
        }
        postProccessAnim.SetBool("IsInside", isInside);
    }
    void OnTriggerEnter(Collider collider)
    {
        ToggleOutside();
    }
}
