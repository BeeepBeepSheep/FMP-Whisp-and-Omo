using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    [Header("MainMenu Menu")]
    public AudioSource mainMenuMusic;

    [Header("Chapter One")]
    public AudioSource currantTrack;

    [SerializeField] private float timeBetweenTracks = 1.5f;
    [SerializeField] private AudioSource prisonSong;
    [SerializeField] private AudioSource courtyardSong;
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

    void Update()
    {
        
    }
}

//UnityEditorInternal.ComponentUtility.CopyComponent(prisonSong);
//UnityEditorInternal.ComponentUtility.PasteComponentAsNew(transform.GetChild(0).gameObject);
