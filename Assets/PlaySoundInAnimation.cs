using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySoundInAnimation : MonoBehaviour
{
    [SerializeField] private AudioSource footstepSound;
    [SerializeField] private OmoMovement omoMovement;

    private void Start()
    {
        omoMovement = GetComponent<OmoMovement>();
    }
    public void PlayFootStepSound()
    {
        if(omoMovement.IsGrounded())
        {
            footstepSound.Play();
        }
    }
}
