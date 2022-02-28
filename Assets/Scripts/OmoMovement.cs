using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OmoMovement : MonoBehaviour
{
    private Rigidbody omoRigidBody;
    private PlayerInput playerInput;
    public float walksSpeed = 1f;
    public float jumpForce = 5;

    private PlayerInputActions playerInputActions;
    private Pause pause;

    private void Awake()
    {
        omoRigidBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        pause = GetComponent<Pause>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }
    void Start()
    {

    }

    private void FixedUpdate()
    {
        //movement
        Walking();
    }
    
    public void Walking()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        if (inputVector != new Vector2(0,0))
        {
            omoRigidBody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * walksSpeed, ForceMode.Force);
            //Debug.Log(inputVector);
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
        if (context.performed)
        {
            //Debug.Log("jump " + context.phase);
            omoRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
