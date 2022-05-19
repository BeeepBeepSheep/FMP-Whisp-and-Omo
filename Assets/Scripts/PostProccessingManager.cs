using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PostProccessingManager : MonoBehaviour
{
    [Header("PostProccessing")]
    [SerializeField] private bool isInside = false;
    [SerializeField] private Animator postProccessAnim;

    [Header("objective")]
    [SerializeField] private ObjectiveManagerChapterOne objectiveManager;
    private bool firstTimeEscape = true;
    
    public void ToggleOutside()
    {
        if (isInside)
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
        if (collider.tag == "Player")
        {
            ToggleOutside();

            if (firstTimeEscape)
            {
                firstTimeEscape = false;
                objectiveManager.section = 3;
                objectiveManager.CheckObjective(null, false);
            }
        }
    }
}
