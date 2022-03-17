using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManagerChapterOne : MonoBehaviour
{
    [SerializeField] private Transform[] objectives;
    [SerializeField] private PlayerManager playerManager;

    [SerializeField] private int currentPuzzle = 0; // puzzle 0 is tutorial, 1 is first pressure plate,
    [SerializeField] private Transform currentObjective;
    [SerializeField] private Animator uiAnim;

    private void Start()
    {
        currentObjective = null;
        foreach (Transform objective in objectives)
        {
            objective.GetComponent<Outline>().enabled = false;
        }
    }
    public void CheckObjective(string type, bool isInteracting) // recieves tag, check if it is start or end of interactable
    {
        Debug.Log("check obj: " + currentPuzzle + ", is interacting = " + isInteracting + ", type is: " + type);

        if (playerManager.hasCompletedTutorial && currentPuzzle == 0 && type == null)
        {
            //Debug.Log("tutorialComplete");
            InitiatePuzzleOne();
        }
        if (currentPuzzle == 1 && type == "PressurePlate" && isInteracting)
        {
            uiAnim.SetTrigger("SendTooComplete");
            currentPuzzle = 2;
            //do open cell doors
        }
        if (currentPuzzle == 2 && type == "PressurePlate" && !isInteracting)
        {
            objectives[0].GetComponent<Outline>().enabled = false; // dissable first pressure plate
            Debug.Log("dissable that");
            //do close cell doors
        }
    }
    private void InitiatePuzzleOne()
    {
        currentObjective = objectives[0];
        currentPuzzle = 1;
        currentObjective.GetComponent<Outline>().enabled = true;
        currentPuzzle = 1;
    }
}
