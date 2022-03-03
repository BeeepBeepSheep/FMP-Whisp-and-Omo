using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OmoAnimationController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody rigidbody;
    private float maxSpeed;
    private OmoMovement omoMovement;

    public float groundedCheckTickRate = 0.01f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        omoMovement = GetComponent<OmoMovement>();
        maxSpeed = omoMovement.currentMaxSpeed;
    }

    private void Update()
    {
        //animator.SetFloat("Speed", rigidbody.velocity.magnitude / maxSpeed);

        StartCoroutine(MyUpdate());
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

            //speed
            animator.SetFloat("Speed", rigidbody.velocity.magnitude / maxSpeed);
        }
    }
}
