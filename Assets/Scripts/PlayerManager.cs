using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Cutscene")]
    [SerializeField] private Outline omoOutline;
    [SerializeField] private OmoMovement omoMovement;
    [SerializeField] private OmoAnimationController omoAnimationController;
    [SerializeField] private WhispOrbitController whispOrbitController;
    [SerializeField] private WhispFollow whispFollow;
    [SerializeField] private WhispAbility whispAbility;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private CinemachineVirtualCamera finalVirtualCam;
    [SerializeField] private CinemachineFreeLook freeLook;
    [SerializeField] private ObjectiveManagerChapterOne objectiveManagerChapterOne;
    [SerializeField] private PlayerInput playerInput;

    [Header("UI")]
    [SerializeField] private CanvasGroup hudGroup;
    [SerializeField] private GameObject lookTutorialPromt;
    [SerializeField] private Animator uiAnim;

    [Header("Tutorial")]
    [SerializeField] private GameObject lookPrompt;
    [SerializeField] private GameObject movePrompt;
    [SerializeField] private GameObject jumpPrompt;

    [SerializeField] private GameObject returnWhispPrompt;
    [SerializeField] private GameObject sendWhispPrompt;

    [SerializeField] private string secondWalkTitle = "Break Whisp Free";
    [SerializeField] private Outline jarOutline;
    [SerializeField] private GameObject whisp;
    [SerializeField] private GameObject sadWhisp;

    private bool hasLookedAround = false;
    private bool hasWalkedAround = false;
    public bool hasJumpedOnTable = false;
    public bool hasFreedWhisp = false;
    public bool hasReturnedWhisp = false;
    private bool hasSwitchedShoulder = false;

    public bool introCutsceneHasEnded = false;
    public bool hasLearntWhispAbility = false;

    public bool hasCompletedTutorial = false;


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
        objectiveManagerChapterOne.enabled = true;
        playerInput.enabled = true;

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
        objectiveManagerChapterOne.enabled = false;

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
    public void WhispIsFree()
    {
        whispOrbitController.enabled = true;
        whispFollow.enabled = true;
        whispFollow.currentTarget = whispFollow.transform;
        hasFreedWhisp = true;

        uiAnim.SetTrigger("BreakTooReturn");
    }
    public void FirstTimeWhispReturn(InputAction.CallbackContext context)
    {
        if (hasFreedWhisp && !hasReturnedWhisp && context.started)
        {
            hasReturnedWhisp = true;
            whispAbility.enabled = true;
            hasLearntWhispAbility = true;

            hasCompletedTutorial = true;
            objectiveManagerChapterOne.CheckObjective(null, true); //send no tag, send no enabling data
            uiAnim.SetTrigger("ReturnTooShoulder");
        }
    }
    public void FirstTimeShoulderChange(InputAction.CallbackContext context)
    {
        if (hasReturnedWhisp && !hasSwitchedShoulder && context.started)
        {
            hasSwitchedShoulder = true;
            uiAnim.SetTrigger("ShoulderTooSend");
        }
    }
}