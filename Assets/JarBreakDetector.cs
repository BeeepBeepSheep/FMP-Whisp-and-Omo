using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarBreakDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.tag == "Jar")
        {
            collider.transform.GetComponent<BreakJar>().ShatterJar();
            Destroy(gameObject);
        }
    }
}
