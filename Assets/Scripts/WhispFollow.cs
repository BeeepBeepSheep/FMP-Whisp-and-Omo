using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhispFollow : MonoBehaviour
{
    public Transform target;

    public float smoothTime = 0.5f;

    public float speed = 1.0f;

    void FixedUpdate()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
