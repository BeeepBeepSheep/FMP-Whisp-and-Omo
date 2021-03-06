using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectiveManagerChapterOne : MonoBehaviour
{
    [Header("element 0 is first presure plate")]
    [SerializeField] private Transform[] objectives;

    [SerializeField] private PlayerManager playerManager;
    
    public int section = 1; // puzzle 0 is tutorial, 1 is first pressure plate, 2 is hallway, 
    //section value is changed in post proccessing manager

    [SerializeField] private Animator uiAnim;
    [SerializeField] private Animator audioAnim;
    [SerializeField] private CanvasController canvasController;

    [Header("Record Progress")]
    [SerializeField] private GameSettings gameSettings;

    [Header("Section One")]
    [SerializeField] private Animator prisonAnim;
    private int stageInSectionOne = 0; // puzzle 0 is tutorial, 1 is first pressure plate
    [SerializeField] private AudioSource gateSound;

    [Header("Section Three")]
    [SerializeField] private Animator craneAnim;
    [SerializeField] private Animator drawbridgeAnim;
    private bool isFirstTimePrisonEscape = true;
    private bool isFirstTimeBridgeOpen = true;
    [SerializeField] private AudioSource playerFootstepSound;
    [SerializeField] private AudioSource drawbridgeSound;
    [SerializeField] private AudioSource craneSound;

    [SerializeField] private Animator comicAnim;

    private void Start()
    {
        foreach (Transform objective in objectives)
        {
            objective.GetComponent<Outline>().enabled = false;
        }
    }
    public void CheckObjective(string recieveType, bool isInteracting) // recieves tag, check if it is start or end of interactable
    {
        //Debug.Log("check obj section: " + section + ", is interacting = " + isInteracting + ", type is: " + recieveType);

        if (section == 1)//tutorial
        {

            if (playerManager.hasCompletedTutorial/* && stageInSectionOne == 0*/ && recieveType == null)
            {
                objectives[0].GetComponent<Outline>().enabled = true;
                stageInSectionOne = 1;
                section = 1;

                drawbridgeAnim.SetTrigger("DrawbridgeIsReady");
            }
            if (stageInSectionOne == 1 && recieveType == "PressurePlate" && isInteracting)
            {
                stageInSectionOne = 2;
                prisonAnim.SetBool("OpenCellDoor", true);
                gateSound.Play();
                uiAnim.SetTrigger("SendTooComplete");
                //do open cell doors
            }
            if (stageInSectionOne == 2 && recieveType == "PressurePlate" && !isInteracting)
            {
                objectives[0].GetComponent<Outline>().enabled = false; // dissable first pressure plate
               
                section = 2; //set to 2 
                CheckObjective(null, false);
                //do close cell doors
            }

            gameSettings.SetChapter_Main_Progress(25);
        }

        else if (section == 2)//hallway
        {
            objectives[1].GetComponent<Outline>().enabled = true;

            if (recieveType == "PressurePlate" && isInteracting)
            {
                prisonAnim.SetBool("MainDoorShouldOpen", true);
                gateSound.Play();

                //do open main doors
            }
            else if (recieveType == "PressurePlate" && !isInteracting)
            {
                prisonAnim.SetBool("MainDoorShouldOpen", false);
                gateSound.Play();
            }
            gameSettings.SetChapter_Main_Progress(50);
        }

        else if (section == 3)//crane and bridge section
        {
            prisonAnim.SetBool("MainDoorShouldOpen", false);
            uiAnim.SetTrigger("PrisonToCourtyard");

            //outlines
            objectives[1].GetComponent<Outline>().enabled = false;
            objectives[2].GetComponent<Outline>().enabled = true;
            objectives[3].GetComponent<Outline>().enabled = true;
            objectives[4].GetComponent<Outline>().enabled = true;

            if (recieveType == "PressurePlateCrane" && isInteracting)
            {
                craneAnim.SetBool("DoRaise", false);
                craneSound.Play();
                //lower crane
            }
            if (recieveType == "PressurePlateCrane" && !isInteracting)
            {
                craneAnim.SetBool("DoRaise", true);
                craneSound.Play();
                //raise crane
            }

            if (recieveType == "PressurePlateDrawbridge" && isInteracting)
            {
                drawbridgeAnim.SetBool("DrawbridgeShouldBeOpen", true);

                if(isFirstTimeBridgeOpen)
                {
                    uiAnim.SetTrigger("BridgeToEscape2");
                    isFirstTimeBridgeOpen = false;
                    objectives[5].GetComponent<Outline>().enabled = true;
                    objectives[6].GetComponent<Outline>().enabled = true;
                }
                //open bridge
                drawbridgeSound.Play();
            }
            if (recieveType == "PressurePlateDrawbridge" && !isInteracting)
            {
                drawbridgeAnim.SetBool("DrawbridgeShouldBeOpen", false);
                drawbridgeSound.Play();
                //close bridge
            }
            gameSettings.SetChapter_Main_Progress(75);
        }
    }
    public void ChapterComplete()
    {
        canvasController.ChapterOneComplete();
        comicAnim.SetTrigger("PlayOutro");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameSettings.SetChapter_Main_Progress(100);
        //playerManager.DeactivateOutro(); is called in animation event
    }
}