using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoodController : MonoBehaviour
{
    public int fullMood = 1; //1 for fine, 0 for sad, use as int
    private OmoMovement omoMovement;

    private OmoAnimationController omoAnimatorScript;

    public GameObject happyBeard;
    public GameObject sadBeard;
    void Awake()
    {

    }
    void Start()
    {
        omoMovement = GetComponent<OmoMovement>();
        omoAnimatorScript = GetComponent<OmoAnimationController>();

        CheckMood();
    }
    public void ToggleMood(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (fullMood == 0) //sad
            {
                fullMood = 1; //set happy
            }
            else if (fullMood == 1)
            {
                fullMood = 0; //set sad
            }
            CheckMood();
        }
    }

    void CheckMood()
    {
        if (fullMood == 0) //sad
        {
            omoMovement.currentMaxSpeed = omoMovement.sadMaxSpeed;

            happyBeard.SetActive(false);
            sadBeard.SetActive(true);
        }
        else if (fullMood == 1)//happy
        {
            omoMovement.currentMaxSpeed = omoMovement.happyMaxSpeed;

            happyBeard.SetActive(true);
            sadBeard.SetActive(false);
        }

        omoAnimatorScript.maxSpeed = omoMovement.currentMaxSpeed;
        omoAnimatorScript.animator.SetFloat("Mood", fullMood);
    }
}
