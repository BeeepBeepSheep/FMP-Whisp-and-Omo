using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OmoAnimationController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody rigidbody;
    public float maxSpeed;
    private OmoMovement omoMovement;
    private MoodController moodController;

    [Header("Time tick intervals")]
    public float groundedCheckTickRate = 0.01f;
    public float checkIdleTime = 15f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        omoMovement = GetComponent<OmoMovement>();
        moodController = GetComponent<MoodController>();

        maxSpeed = omoMovement.currentMaxSpeed;

        StartCoroutine(MyUpdate());
        StartCoroutine(DoIdleAction());
    }

    public void DoPoint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger("Point");
        }
    }
    IEnumerator MyUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(groundedCheckTickRate);

            //jump anim
            animator.SetBool("IsGrounded", omoMovement.IsGrounded());

            ////speed
            animator.SetFloat("Speed", rigidbody.velocity.magnitude / maxSpeed);
        }
    }

    IEnumerator DoIdleAction()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkIdleTime);

            if(moodController.fullMood == 0)//if sad
            {
                animator.SetBool("DoIdleAction", true);
                animator.SetTrigger("SadIdleKick");
            }
            else// if happy
            {
                int ran = Random.Range(-1, 2);
                if (ran == 0)
                {
                    animator.SetBool("DoIdleAction", true);
                    animator.SetTrigger("IdleArmSwing");
                }
                else
                {
                    animator.SetBool("DoIdleAction", true);
                    animator.SetTrigger("IdleStretch");
                }
            }
        }
    }
    public void CancleIdleActions()
    {
        animator.SetBool("DoIdleAction", false);
    }
}