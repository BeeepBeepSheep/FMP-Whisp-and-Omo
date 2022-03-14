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

    [SerializeField] private PlayerManager playerManager;

    public void DoWhispAbility(InputAction.CallbackContext context)
    {
        if (context.started && playerManager.hasLearntWhispAbility)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1000f, ~rayIgnore))
            {
                if(hit.transform.tag == "WhispOnlyInteractable")
                {
                    hit.transform.GetComponent<Interactable>().isInteractingWithWhisp = true;
                }

                GameObject whispTargetPoint = Instantiate(newWhispMovePoint, hit.point, Quaternion.LookRotation(hit.normal));
                whispFollow.currentTarget = whispTargetPoint.transform;
            }
        }
        else if (context.started && !playerManager.hasLearntWhispAbility)
        {
            Debug.Log("not yet");
        }
    }
}