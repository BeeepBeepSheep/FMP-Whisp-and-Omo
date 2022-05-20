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

    [SerializeField] private float timeBetweenTracks = 1.5f;
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
            footStepMaxVolume = footStepSound.volume;
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            currantTrack = mainMenuMusic;
        }
    }
    public void StartGame()
    {
        UnityEditorInternal.ComponentUtility.CopyComponent(prisonSong);
        UnityEditorInternal.ComponentUtility.PasteComponentValues(currantTrack);
        currantTrack = transform.GetChild(0).GetComponent<AudioSource>();

        currantTrack.Play();
    }
    public void SwitchToCourtyard()
    {
        currantTrack.Stop();
        UnityEditorInternal.ComponentUtility.CopyComponent(courtyardSong);
        UnityEditorInternal.ComponentUtility.PasteComponentValues(currantTrack);
        currantTrack = transform.GetChild(0).GetComponent<AudioSource>();

        //yield return new WaitForSeconds(timeBetweenTracks);
        
        currantTrack.Play();
    }
    public void ToggleFottstepVolume(bool isInside)
    {
        if(isInside)
        {
            footStepSound.volume = footStepMaxVolume;
        }
        else
        {
            footStepSound.volume = footStepMinVolume;
        }
    }
}