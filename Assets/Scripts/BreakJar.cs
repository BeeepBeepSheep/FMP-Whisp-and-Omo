using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakJar : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject whisp;
    [SerializeField] private GameObject sadWhisp;
    [SerializeField] private Outline jarOutline;
    [SerializeField] private GameObject jarLid;

    [SerializeField] private bool isMainJar;

    void Start()
    {
    }

    public void ShatterJar()
    {
        jarLid.AddComponent<Rigidbody>();
        jarLid.GetComponent<MeshCollider>().convex = true;
        
        if (isMainJar)
        {
            Destroy(sadWhisp);

            sadWhisp.transform.parent = null;
            jarOutline.enabled = false;
            playerManager.WhispIsFree();

            Destroy(sadWhisp);
        }

        List<Transform> children = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        foreach (Transform tr in transform) children.Add(tr);
        foreach (Transform child in children)
        {
            child.parent = null;
            child.gameObject.SetActive(true);
        }

        Destroy(gameObject);
    }
}