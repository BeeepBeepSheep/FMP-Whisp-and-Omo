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
    public void CheckObjective(string type) // recieves tag
    {
        if(playerManager.hasCompletedTutorial)
        {
            Debug.Log("tutorialComplete");
            InitiatePuzzleOne();
        }
        if (currentPuzzle == 1 && type == "PressurePlate")
        {
            uiAnim.SetTrigger("SendTooComplete");
            Debug.Log("work");
        }
    }
    private void InitiatePuzzleOne()
    {
        //playerManager.enabled = false;

        currentObjective = objectives[0];
        currentPuzzle = 1;
        currentObjective.GetComponent<Outline>().enabled = true;
        currentPuzzle = 1;
        Debug.Log("test");
    }
}
