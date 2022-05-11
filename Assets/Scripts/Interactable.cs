using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    // interact types, door, bridge, light, break, spawn
    public bool interactTypeIsHold = true;
    [SerializeField] private bool isInteracting = false;
    [SerializeField] private ObjectiveManagerChapterOne objectiveManagerChapterOne;
    [SerializeField] private SideQuestManagerChapterOne sideQuestManagerChapterOne;

    [Header("Whisp Only")]
    public bool isInteractingWithWhisp = false;
    public bool isTorch = false;
    [SerializeField] private float torchLifeTime;

    [Header("Section 3")]
    public bool isCraneButton = false;
    public bool isDrawBridgeButton = false;
    public bool isFinalTrigger = false;

    void Awake()
    {
        if (gameObject.tag == "PressurePlate")
        {
            interactTypeIsHold = true;
        }
        else if (gameObject.tag == "WhispLightSwitch" || gameObject.tag == "Jar")
        {
            interactTypeIsHold = false;
        }
    }
    void Start()
    {
        if (isTorch)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        if(gameObject.tag == "Jar")
        {
            foreach (Transform child in transform)
            {
                
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        isInteracting = true;

        //pressure plate
        if (gameObject.tag == "PressurePlate")
        {
            if (collider.tag == "Player" || collider.tag == "Whisp")
            {
                //Debug.Log("interacted with anything");
                gameObject.GetComponent<MeshRenderer>().enabled = false;

                CheckTheObjective();
            }
        }

        //whisp only
        //code not used in chapter one----
        //if (isInteractingWithWhisp && collider.tag == "Whisp" && gameObject.tag == "WhispOnlyInteractable" || gameObject.tag == "WhispLightSwitch")
        //{
        //    //Debug.Log("interacted with whisp");
        //}----

        if (collider.tag == "Whisp" && gameObject.tag == "WhispLightSwitch")
        {

            //Debug.Log("lightswitch");
            if (isTorch)
            {
                //Debug.Log("torch");
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
                GetComponent<Outline>().enabled = false;
                StartCoroutine(TurnTorchOff());
            }
        }

        //jar
        if (collider.tag == "Player" || collider.tag == "Whisp")
        {
            if (gameObject.tag == "Jar")
            {
                sideQuestManagerChapterOne.IncreaseFreedCount();

                GetComponent<BreakJar>().ShatterJar();
            }
        }

        //end of chapter
        if(collider.tag == "Player" && isFinalTrigger)
        {
            objectiveManagerChapterOne.ChapterComplete();
        }
        //Debug.Log("interacted");
    }

    void OnTriggerExit(Collider collider)
    {
        if (interactTypeIsHold)
        {
            isInteracting = false;
            //pressure plate
            if (gameObject.tag == "PressurePlate")
            {
                if (collider.tag == "Player" || collider.tag == "Whisp")
                {
                    //Debug.Log("uninteracted with anything, ");
                    gameObject.GetComponent<MeshRenderer>().enabled = true;

                    CheckTheObjective();
                }
            }
            //whisp only
            if (isInteractingWithWhisp && collider.tag == "Whisp" && gameObject.tag == "WhispOnlyInteractable")
            {
                //Debug.Log("uninteracted with whisp");
                isInteractingWithWhisp = false;
            }
        }
        //Debug.Log("uninteracted");
    }
    private void CheckTheObjective()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "ChapterOne")
        {
            if (!isCraneButton && !isDrawBridgeButton)
            {
                objectiveManagerChapterOne.CheckObjective(transform.tag, isInteracting);
            }

            else if (isCraneButton)
            {
                objectiveManagerChapterOne.CheckObjective("PressurePlateCrane", isInteracting);
            }
            else if (isDrawBridgeButton)
            {
                objectiveManagerChapterOne.CheckObjective("PressurePlateDrawbridge", isInteracting);
            }
            else if (isFinalTrigger)
            {
                Debug.Log("final interactable trigger");
                objectiveManagerChapterOne.CheckObjective("ChapterOneComplete", isInteracting);
            }
        }
        // repeat for other chapters
    }
    IEnumerator TurnTorchOff()
    {
        yield return new WaitForSeconds(torchLifeTime);

        GetComponent<Outline>().enabled = true;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}