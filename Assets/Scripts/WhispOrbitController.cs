using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhispOrbitController : MonoBehaviour
{
    public float speed;

    public Transform targetPoint;
    public Transform myTargetPosition;

    public float tickPositionResetTime;

    void Start()
    {
        StartCoroutine(PositioTick());
    }
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }

    IEnumerator PositioTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(tickPositionResetTime);
            transform.position = myTargetPosition.position;
        }
    }
}
