using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissableJarPiece : MonoBehaviour
{
    [SerializeField] private float dissableTime = 4;

    public void DissableMe()
    {
        //yield return new WaitForSeconds(dissableTime);
        Debug.Log("Dissablejarpiece");
        //GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Collider>().enabled = false;
    }
}