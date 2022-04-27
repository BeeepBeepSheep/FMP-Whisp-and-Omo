using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private WhispFollow whispFollowScript;

    public void TeleportWhisp()
    {
        whispFollowScript.TeleportToOmo();
    }
}
