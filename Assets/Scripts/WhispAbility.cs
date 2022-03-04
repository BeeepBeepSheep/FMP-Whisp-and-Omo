using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WhispAbility : MonoBehaviour
{
    public WhispFollow whispFollow;
    public Camera cam;

    public GameObject newWhispMovePoint;
    public LayerMask rayIgnore;

    public void DoWhispAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {

            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1000f, ~rayIgnore))
            {
                if(hit.transform.tag == "Interactable")
                {
                    hit.transform.GetComponent<Interactable>().Interacted();
                }
                GameObject whispTargetPoint = Instantiate(newWhispMovePoint, hit.point, Quaternion.LookRotation(hit.normal));
                whispFollow.currentTarget = whispTargetPoint.transform;
            }
        }
    }
}