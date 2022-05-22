using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTriggerPrisonExit : MonoBehaviour
{
    [Header("chapterOne")]
    [SerializeField] private Animator audioAnim;
    [SerializeField] private AudioManager audioManager;
    private bool isInside = true;
    private bool firstTimeEscape = true;

    void OnTriggerEnter(Collider collider)
    {
        if (firstTimeEscape && collider.tag == "Player")
        {
            audioManager.hasVolumeControl = false;
            audioAnim.SetTrigger("musicFade");
            firstTimeEscape = false;
        }

        if(isInside)
        {
            isInside = false;
        }
        else
        {
            isInside = true;
        }
        audioManager.ToggleFottstepVolume(isInside);
    }
}
