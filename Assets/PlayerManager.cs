using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private GameObject omoMesh;
    [SerializeField] private OmoMovement omoMovement;
    [SerializeField] private OmoAnimationController omoAnimationController;
    [SerializeField] private WhispOrbitController whispOrbitController;
    [SerializeField] private WhispFollow whispFollow;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private ObjectiveManager objectiveManager;
    [SerializeField] private CinemachineVirtualCamera finalVirtualCam;
    [SerializeField] private CinemachineFreeLook freeLook;

    public void ActivateSequence1()
    {
        omoMesh.SetActive(true);
        omoAnimationController.enabled = true;
        whispOrbitController.enabled = true;
        cameraController.enabled = true;
        objectiveManager.enabled = true;

        finalVirtualCam.enabled = false;
        freeLook.enabled = true;
    }
    public void ActivateSequence2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
            omoMovement.enabled = true;
            whispFollow.enabled = true;
            omoAnimationController.animator.SetTrigger("SitToStand");
        }
    }
    public void Deactivate()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        omoMesh.SetActive(false);
        omoMovement.enabled = false;
        omoAnimationController.enabled = false;
        whispOrbitController.enabled = false;
        whispFollow.enabled = false;
        cameraController.enabled = false;
        objectiveManager.enabled = false;

        freeLook.enabled = false;
        finalVirtualCam.enabled = true;
    }
}
