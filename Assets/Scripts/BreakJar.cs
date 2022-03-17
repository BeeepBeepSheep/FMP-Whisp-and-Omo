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

    void Start()
    {
    }

    public void ShatterJar()
    {
        Destroy(sadWhisp);
        jarLid.AddComponent<Rigidbody>();
        jarLid.GetComponent<MeshCollider>().convex = true;

        sadWhisp.transform.parent = null;
        List<Transform> children = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        foreach (Transform tr in transform) children.Add(tr);
        foreach (Transform child in children)
        {
            child.parent = null;
            child.gameObject.SetActive(true);
        }
        
        //sadWhisp.SetActive(false);
        jarOutline.enabled = false;
        playerManager.WhispIsFree();

        Destroy(sadWhisp);
        Destroy(gameObject);
    }
}