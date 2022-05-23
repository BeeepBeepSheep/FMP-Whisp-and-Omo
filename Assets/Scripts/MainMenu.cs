using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private ButtonLogic playButton;
    [SerializeField] private ButtonLogic settingsButton;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private AudioSource buttonSound;

    [Header("Chapters")]
    [SerializeField] private GameObject chapterSelection;
    public bool chaptersIsShowing = false;
    [SerializeField] private GameObject chapterOneButton;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        levelLoader.gameObject.SetActive(true);
    }
    private void Start()
    {
        HideChapters();
    }
    public void ToggleShowChapters()
    {
        if (chaptersIsShowing)
        {
            HideChapters();
            return;
        }
        else
        {
            ShowChapters();
            return;
        }
    }
    private void ShowChapters()
    {
        chaptersIsShowing = true;
        chapterSelection.SetActive(true);
        gameSettings.HideSettings();

        buttonSound.Play();
    }
    public void HideChapters()
    {
        chaptersIsShowing = false;
        chapterSelection.SetActive(false);

        buttonSound.Play();
    }
    public void LoadChapterOne()
    {
        StartCoroutine(levelLoader.LoadEsynchronously("ChapterOne"));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (gameSettings.settingsIsOn)
            {
                gameSettings.HideSettings();

                eventSystem.SetSelectedGameObject(null);
                eventSystem.SetSelectedGameObject(settingsButton.gameObject);
                settingsButton.Button_Select();
                buttonSound.Play();
            }
            else if (chaptersIsShowing)
            {
                HideChapters();

                eventSystem.SetSelectedGameObject(null);
                eventSystem.SetSelectedGameObject(settingsButton.gameObject);
                playButton.Button_Select();
                buttonSound.Play();
            }
        }
    }
}
