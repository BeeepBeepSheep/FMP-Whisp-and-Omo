using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Outline omoOutline;
    [SerializeField] private OmoMovement omoMovement;
    [SerializeField] private OmoAnimationController omoAnimationController;
    [SerializeField] private WhispOrbitController whispOrbitController;
    [SerializeField] private WhispFollow whispFollow;
    [SerializeField] private WhispAbility whispAbility;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private ObjectiveManager objectiveManager;
    [SerializeField] private CinemachineVirtualCamera finalVirtualCam;
    [SerializeField] private CinemachineFreeLook freeLook;

    [Header("UI")]
    [SerializeField] private CanvasGroup hudGroup;
    [SerializeField] private GameObject lookTutorialPromt;
    [SerializeField] private Animator uiAnim;

    [Header("Tutorial")]
    [SerializeField] private GameObject lookPrompt;
    [SerializeField] private GameObject movePrompt;
    [SerializeField] private GameObject jumpPrompt;

    [SerializeField] private GameObject sendWhispPrompt;
    [SerializeField] private GameObject returnWhispPrompt;
    [SerializeField] private string secondWalkTitle = "Break Whisp Free";
    [SerializeField] private Outline jarOutline;
    [SerializeField] private GameObject whisp;
    [SerializeField] private GameObject sadWhisp;

    private bool hasLookedAround = false;
    private bool hasWalkedAround = false;
    public bool hasJumpedOnTable = false;

    public bool introCutsceneHasEnded = false;
    public bool hasLearntWhispAbility = false;


    private void Start()
    {
        lookPrompt.SetActive(true);
        movePrompt.SetActive(false);
        jumpPrompt.SetActive(false);
        sendWhispPrompt.SetActive(false);
        returnWhispPrompt.SetActive(false);
    }
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
        jarOutline.enabled = false;
        whisp.SetActive(false);
        sadWhisp.SetActive(true);
    }
    public void IntroCutsceneEnded()
    {
        introCutsceneHasEnded = true;
    }
    public void FirstTimeLook()
    {
        if (!hasLookedAround && introCutsceneHasEnded)
        {
            //Debug.Log("first look");
            StartCoroutine(TutorialStage2());
            hasLookedAround = true;
        }
    }
    private IEnumerator TutorialStage2()
    {
        //after first look and before walk
        yield return new WaitForSeconds(1);
        uiAnim.SetTrigger("LookTooMove");

        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;

        omoAnimationController.animator.SetTrigger("SitToStand");

        yield return new WaitForSeconds(3); // wait for stand up anim
        omoMovement.enabled = true;
        jarOutline.enabled = true;
    }
    public void FirstTimeWalk()
    {
        if (hasLookedAround && omoMovement.isActiveAndEnabled && !hasWalkedAround)
        {
            //Debug.Log("first walk");
            StartCoroutine(TutorialStage3());
            hasWalkedAround = true;
        }
    }
    private IEnumerator TutorialStage3()
    {
        //after first walk and before jump
        yield return new WaitForSeconds(1);
        uiAnim.SetTrigger("MoveTooJump");
    }
    public void FirstTimeJump(InputAction.CallbackContext context)
    {
        if (hasWalkedAround && !hasJumpedOnTable && context.started)
        {
            //Debug.Log("first jump");
            hasJumpedOnTable = true;
            StartCoroutine(TutorialStage4());
        }
    }
    private IEnumerator TutorialStage4()
    {
        //after first jump and before whisp freed
        movePrompt.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = secondWalkTitle;
        
        yield return new WaitForSeconds(1);
        uiAnim.SetTrigger("JumpTooBreak");
    }
    public bool WhispIsFree()
    {
        whispOrbitController.enabled = true;
        whispFollow.enabled = true;
        whispFollow.currentTarget = whispFollow.transform;
        return true;
    }
    public void FirstTimeWhispReturn()
    {
        if (hasJumpedOnTable && WhispIsFree())
        {
            //hasJumpedOnTable = true;
            //StartCoroutine(TutorialStage4());
        }
    }
}