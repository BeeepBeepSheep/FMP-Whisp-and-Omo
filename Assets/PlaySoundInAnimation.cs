using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySoundInAnimation : MonoBehaviour
{
    [SerializeField] private AudioSource footstepSound;
    public void PlayFootStepSound()
    {
        footstepSound.Play();
    }
}
