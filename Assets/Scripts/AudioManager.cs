using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    [Header("MainMenu Menu")]
    public AudioSource mainMenuMusic;

    [Header("Chapter One")]
    public AudioSource currantTrack;

    public float musicVolume;
    [SerializeField] private float timeCheck = 0.1f;
    public bool hasVolumeControl;
    [SerializeField] private AudioSource cutscenesong;
    [SerializeField] private AudioSource prisonSong;
    [SerializeField] private AudioSource courtyardSong;
    [SerializeField] private AudioSource footStepSound;
    [SerializeField] private float footStepMaxVolume = 0.4f;
    [SerializeField] private float footStepMinVolume = 0.2f;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "ChapterOne")
        {
            currantTrack = cutscenesong;
            hasVolumeControl = false;
            footStepMaxVolume = footStepSound.volume;

        }
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            currantTrack = mainMenuMusic;
        }
    }
    public void StartGame()
    {
        hasVolumeControl = true;
        StartCoroutine(CheckVolume());
        currantTrack.Stop();
        currantTrack = prisonSong;
        currantTrack.Play();
    }
    public void SwitchToCourtyard()
    {
        currantTrack.Stop();
        currantTrack = courtyardSong;
        currantTrack.Play();
    }
    public void ToggleFottstepVolume(bool isInside)
    {
        if (isInside)
        {
            footStepSound.volume = footStepMaxVolume;
        }
        else
        {
            footStepSound.volume = footStepMinVolume;
        }
    }
    IEnumerator CheckVolume()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeCheck);
            currantTrack.volume = musicVolume;
        }
    }
}