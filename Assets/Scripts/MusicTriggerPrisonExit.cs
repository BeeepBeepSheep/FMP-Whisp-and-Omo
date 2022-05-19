using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTriggerPrisonExit : MonoBehaviour
{
    [Header("chapterOne")]
    [SerializeField] private Animator audioAnim;
    private bool firstTimeEscape = true;

    void OnTriggerEnter(Collider collider)
    {
        if (firstTimeEscape && collider.tag == "Player")
        {
            audioAnim.SetTrigger("musicFade");
            firstTimeEscape = false;
        }
    }
}
