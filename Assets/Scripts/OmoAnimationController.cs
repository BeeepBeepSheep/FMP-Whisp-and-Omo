using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OmoAnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    private float maxSpeed;
    private OmoMovement omoMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        omoMovement = GetComponent<OmoMovement>();
        maxSpeed = omoMovement.maxSpeed;
    }

    private void Update()
    {
        animator.SetFloat("Speed", rigidbody.velocity.magnitude / maxSpeed);

        //jump anim
        animator.SetBool("IsGrounded", omoMovement.IsGrounded());
    }
    public void DoPoint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger("Point");
        }
    }
}
