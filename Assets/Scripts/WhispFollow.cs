using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WhispFollow : MonoBehaviour
{
    public Transform currentTarget;
    public Transform omoTarget;

    public float smoothTime = 0.5f;

    public float currentSpeed = 1.0f;
    public float normalSpeed = 1.0f;
    public float flyTooSpeed = 3.0f;

    
    void Start()
    {
        currentSpeed = normalSpeed;
    }
    void FixedUpdate()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        float step = currentSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);
    }

    public void ResetTarget(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentTarget = omoTarget;

            GameObject[] oldTargets;
            oldTargets = GameObject.FindGameObjectsWithTag("WhispTargetUseless");

            foreach (GameObject oldTarget in oldTargets)
            {
                Destroy(oldTarget);
            }
        }
    }
    void OnDestroy()
    {
        Debug.Log("dead");
    }
}
