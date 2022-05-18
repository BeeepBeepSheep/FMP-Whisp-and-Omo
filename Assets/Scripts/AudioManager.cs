using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    [Header("MainMenu Menu")]
    public AudioSource mainMenuMusic;

    public AudioSource currantTrack;

    [SerializeField] private AudioSource prisonSong;
    public void StartGame()
    {
        currantTrack = prisonSong;
        currantTrack.Play();
    }

    void Update()
    {
        
    }
}
