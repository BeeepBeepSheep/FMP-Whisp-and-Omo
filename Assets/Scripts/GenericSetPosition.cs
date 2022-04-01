using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSetPosition : MonoBehaviour
{
    public Transform myTargetPosition;

    public float tickPositionResetTime;

    void Start()
    {
        StartCoroutine(PositioTick());
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
