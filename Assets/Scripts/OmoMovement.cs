using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OmoMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private PlayerInput playerInput;

    public float movementForce = 1f;
    public float maxSpeed = 5f;
    public float jumpForce = 10;
    private Vector3 forceDirection = Vector3.zero;
    private InputAction moveAction;

    public Camera cam;

    private PlayerInputActions playerInputActions;
    private Pause pauseScript;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        pauseScript = GetComponent<Pause>();
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Jump.started += Jump;
        moveAction = playerInputActions.Player.Movement;

        playerInputActions.Player.Enable();
    }

    private void FixedUpdate()
    {
        Movement();
        GravityMultiplyer();
        LookAt();
    }

    private void Movement()
    {
        //movement
        forceDirection += moveAction.ReadValue<Vector2>().x * GetCameraRight(cam) * movementForce;
        forceDirection += moveAction.ReadValue<Vector2>().y * GetCameraForward(cam) * movementForce;

        rigidbody.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        Vector3 horizontalVelocity = rigidbody.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rigidbody.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rigidbody.velocity.y;
        }
    }
    private void LookAt()
    {
        Vector3 direction = rigidbody.velocity;
        direction.y = 0f;

        if (moveAction.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            this.rigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            rigidbody.angularVelocity = Vector3.zero;
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
        }
    }
    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }
    private void GravityMultiplyer()
    {
        if (rigidbody.velocity.y < 0f)
        {
            rigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }
    }
    private Vector3 GetCameraForward(Camera cam)
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }
    private Vector3 GetCameraRight(Camera cam)
    {
        Vector3 right = cam.transform.right;
        right.y = 0;
        return right.normalized;
    }
    //--------------------------------------
}
