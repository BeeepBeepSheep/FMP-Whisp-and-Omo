using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhispFollow : MonoBehaviour
{
    public Transform target;

    public float smoothTime = 0.5f;

    public float speed = 1.0f;

    void Awake()
    {
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        //if (Vector3.Distance(transform.position, target.position) < 0.001f)
        //{
        //    // Swap the position of the cylinder.
        //    target.position *= -1.0f;
        //}
    }
}
