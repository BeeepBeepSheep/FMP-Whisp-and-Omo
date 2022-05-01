using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProccessingManager : MonoBehaviour
{
    [Header("PostProccessing")]
    bool isInside = true;
    [SerializeField] private Animator postProccessAnim;

    [Header("objective")]
    [SerializeField] private ObjectiveManagerChapterOne objectiveManager;
    private bool firstTimeEscape = true;
    void ToggleOutside()
    {
        if(isInside)
        {
            isInside = false;
        }
        else
        {
            isInside = true;
        }
        postProccessAnim.SetBool("IsInside", isInside);
    }
    void OnTriggerEnter(Collider collider)
    {
        ToggleOutside();

        if(firstTimeEscape)
        {
            objectiveManager.section = 3;
            firstTimeEscape = false;
        }
    }
}
