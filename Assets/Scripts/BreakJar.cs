using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BreakJar : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject whisp;
    [SerializeField] private GameObject sadWhisp;
    [SerializeField] private Outline jarOutline;
    [SerializeField] private GameObject jarLid;

    [SerializeField] private bool isMainJar;
    [SerializeField] private Transform jarPieceHolder;

    [SerializeField] private float dissableTime = 4;
    [SerializeField] private AudioSource jarBreakSound;

    private void Start()
    {
        jarBreakSound = GetComponent<AudioSource>();
    }
    public void ShatterJar()
    {
        jarLid.AddComponent<Rigidbody>();
        jarLid.GetComponent<MeshCollider>().convex = true;

        jarBreakSound.Play();

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

        StartCoroutine(DissableJarPiece());

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().detectCollisions = false;
        GetComponent<MeshCollider>().enabled = false;

    }
    private IEnumerator DissableJarPiece()
    {
        yield return new WaitForSeconds(dissableTime);

        foreach (Transform jarPiece in jarPieceHolder)
        {
            jarPiece.GetComponent<Rigidbody>().useGravity = false;
            jarPiece.GetComponent<Collider>().enabled = false;
            jarPiece.GetComponent<Rigidbody>().detectCollisions = false;
        }
        //Debug.Log("Dissablejarpiece");
        
    }
}