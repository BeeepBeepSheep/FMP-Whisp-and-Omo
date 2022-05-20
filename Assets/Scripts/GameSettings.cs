using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameSettings : MonoBehaviour
{
    [Header("UI")]
    public bool settingsIsOn = false;
    [SerializeField] private GameObject settingsBackground;
    public Button controlsButton;
    public Button videoButton;
    public Button audioButton;
    [SerializeField] private EventSystem eventSystem;

    [Header("-----------")]
    [HideInInspector] public int selectedIndex; // 1 = contols, 2 = video, 3 = audio
    [SerializeField] private GameObject controlsSettings;
    [SerializeField] private GameObject videoSettings;
    [SerializeField] private GameObject audioSettings;

    void Start()
    {
        ShowControlsSettings();
        settingsBackground.SetActive(false);
    }
    public void ToggleSettings()
    {
        if (settingsIsOn)
        {
            HideSettings();
            settingsIsOn = false;
            return;
        }
        else
        {
            ShowSettings();
            settingsIsOn = true;
            return;
        }
    }
    public void ShowSettings()
    {
        settingsBackground.SetActive(true);
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(controlsButton.gameObject);
    }
    public void HideSettings()
    {
        settingsBackground.SetActive(false);
    }

    public void ShowControlsSettings()
    {
        controlsSettings.SetActive(true);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
        selectedIndex = 1;
    }
    public void ShowVideoSettings()
    {
        controlsSettings.SetActive(false);
        videoSettings.SetActive(true);
        audioSettings.SetActive(false);
        selectedIndex = 2;
    }
    public void ShowAudioSettings()
    {
        controlsSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(true);
        selectedIndex = 3;
    }
}
