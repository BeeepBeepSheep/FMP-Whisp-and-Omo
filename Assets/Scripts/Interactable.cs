using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    // interact types, door, bridge, light, break, spawn
    public bool interactTypeIsHold = true;

    [Header("Whisp Only")]
    public bool isInteractingWithWhisp = false;
    public bool isTorch = false;
    [SerializeField] private float torchLifeTime;

    [SerializeField] private bool isInteracting = false;
    [SerializeField] private ObjectiveManagerChapterOne objectiveManagerChapterOne;

    void Awake()
    {
        if (gameObject.tag == "PressurePlate")
        {
            interactTypeIsHold = true;
        }
        else if (gameObject.tag == "WhispLightSwitch")
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
        if (isInteractingWithWhisp && collider.tag == "Whisp" && gameObject.tag == "WhispOnlyInteractable" || gameObject.tag == "WhispLightSwitch")
        {
            //Debug.Log("interacted with whisp");
        }

        if(collider.tag == "Whisp" && gameObject.tag == "WhispLightSwitch")
        {
            
            //Debug.Log("lightswitch");
            if(isTorch)
            {
                //Debug.Log("torch");
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
                StartCoroutine(TurnTorchOff());
            }
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
            objectiveManagerChapterOne.CheckObjective(transform.tag, isInteracting);
        }
        // repeat for other chapters
    }
    IEnumerator TurnTorchOff()
    {
        yield return new WaitForSeconds(torchLifeTime);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}