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

    [Header("Section One")]
    [SerializeField] private Animator prisonAnim;
    private int stageInSectionOne = 0; // puzzle 0 is tutorial, 1 is first pressure plate

    [Header("Section Three")]
    [SerializeField] private Animator craneAnim;
    [SerializeField] private Animator drawbridgeAnim;

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

            //Debug.Log("stage is: " + stageInSectionOne);
        }

        else if (section == 2)//hallway
        {
            objectives[1].GetComponent<Outline>().enabled = true;

            if (recieveType == "PressurePlate" && isInteracting)
            {
                prisonAnim.SetBool("MainDoorShouldOpen", true);

                //do open main doors
            }
            else if (recieveType == "PressurePlate" && !isInteracting)
            {
                prisonAnim.SetBool("MainDoorShouldOpen", false);
            }
        }

        else if (section == 3)//crane and bridge section
        {
            Debug.Log("section is 3");
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
                //lower crane
            }
            if (recieveType == "PressurePlateCrane" && !isInteracting)
            {
                craneAnim.SetBool("DoRaise", true);
                //raise crane
            }

            if (recieveType == "PressurePlateDrawbridge" && isInteracting)
            {
                drawbridgeAnim.SetBool("DrawbridgeShouldBeOpen", true);
                //open bridge
            }
            if (recieveType == "PressurePlateDrawbridge" && !isInteracting)
            {
                drawbridgeAnim.SetBool("DrawbridgeShouldBeOpen", false);
                //close bridge
            }
        }
    }
}