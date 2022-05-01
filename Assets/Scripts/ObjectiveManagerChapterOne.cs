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

    [SerializeField] private Transform currentObjective;
    [SerializeField] private Animator uiAnim;

    [Header("Section One")]
    [SerializeField] private Animator prisonAnim;
    private int stageInSectionOne = 0; // puzzle 0 is tutorial, 1 is first pressure plate

    [Header("Section Two")]
    private int stageInSectionTwo = 0;

    [Header("Section Three")]
    [SerializeField] private Animator craneAnim;
    private int stageInSectionThree = 0; 

    private void Start()
    {
        currentObjective = null;
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
                InitiateFirstButton();
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
            stageInSectionTwo = 1;
            objectives[1].GetComponent<Outline>().enabled = true;

            if (stageInSectionTwo == 1 && recieveType == "PressurePlate" && isInteracting)
            {
                prisonAnim.SetBool("MainDoorShouldOpen", true);

                //do open main doors
            }
            else if (stageInSectionTwo == 1 && recieveType == "PressurePlate" && !isInteracting)
            {
                prisonAnim.SetBool("MainDoorShouldOpen", false);
            }
                Debug.Log("section 2: " + section);
        }

        else if (section == 3)//crane section
        {
            prisonAnim.SetBool("MainDoorShouldOpen", false);
            objectives[1].GetComponent<Outline>().enabled = false;

            //elements in objectives will change

            //Debug.Log("stage in section 3 is: " + stageInSectionThree);
            //objectives[2].GetComponent<Outline>().enabled = true; // enable outline for pressure plate

            if (/*stageInSectionThree == 1 && */recieveType == "PressurePlate" && isInteracting)
            {
                craneAnim.SetBool("DoRaise", false);
                //lower crane
            }
            if (/*stageInSectionThree == 2 && */recieveType == "PressurePlate" && !isInteracting)
            {
                craneAnim.SetBool("DoRaise", true);
                //raise crane
            }
        }
    }
    private void InitiateFirstButton()// turn on tutorial button
    {
        currentObjective = objectives[0]; 
        currentObjective.GetComponent<Outline>().enabled = true;
        stageInSectionOne = 1;
        section = 1;
    }
}