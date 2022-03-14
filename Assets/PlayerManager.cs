using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Outline omoOutline;
    [SerializeField] private OmoMovement omoMovement;
    [SerializeField] private OmoAnimationController omoAnimationController;
    [SerializeField] private WhispOrbitController whispOrbitController;
    [SerializeField] private WhispFollow whispFollow;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private ObjectiveManager objectiveManager;
    [SerializeField] private CinemachineVirtualCamera finalVirtualCam;
    [SerializeField] private CinemachineFreeLook freeLook;

    [Header("UI")]
    [SerializeField] private CanvasGroup hudGroup;
    [SerializeField] private GameObject lookTutorialPromt;
    [SerializeField] private Animator uiAnim;

    private bool hasLookedAround = false;
    private bool hasWalkedAround = false;
    public bool introCutsceneHasEnded = false;

    public void ActivateSequence1()
    {
        //tutorial part 1

        omoOutline.enabled = true;
        omoAnimationController.enabled = true;
        whispOrbitController.enabled = true;
        cameraController.enabled = true;
        objectiveManager.enabled = true;

        finalVirtualCam.enabled = false;
        freeLook.enabled = true;
    }
    
    public void Deactivate()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        omoOutline.enabled = false;

        omoAnimationController.enabled = false;
        omoMovement.enabled = false;
        whispOrbitController.enabled = false;
        whispFollow.enabled = false;
        cameraController.enabled = false;
        objectiveManager.enabled = false;

        freeLook.enabled = false;
        finalVirtualCam.enabled = true;
    }
    public void IntroCutsceneEnded()
    {
        introCutsceneHasEnded = true;
    }
    public void FirstTimeLook()
    {
        if(!hasLookedAround && introCutsceneHasEnded)
        {
            //Debug.Log("first look");
            StartCoroutine(TutorialStage2());
            hasLookedAround = true;
        }
    }
    private IEnumerator TutorialStage2()
    {
        //after look
        yield return new WaitForSeconds(1);
        uiAnim.SetTrigger("LookTooMove");

        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;

        omoAnimationController.animator.SetTrigger("SitToStand");

        yield return new WaitForSeconds(3); // time for stand up anim
        omoMovement.enabled = true;
    }
    public void FirstTimeWalk()
    {
        if (hasLookedAround && omoMovement.isActiveAndEnabled && !hasWalkedAround)
        {
            Debug.Log("first walk");
            hasWalkedAround = true;
        }
    }
}
