using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private ButtonLogic playButton;
    [SerializeField] private ButtonLogic settingsButton;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private AudioSource buttonSound;
    [Header("Save data")]
    [SerializeField] private GameObject clearSaveDataObject;
    [SerializeField] private ButtonLogic cancleClearSaveDataButton;

    [Header("Chapters")]
    [SerializeField] private GameObject chapterSelection;
    public bool chaptersIsShowing = false;
    [SerializeField] private GameObject chapterOneButton;
    private bool clearSaveDataScrenIsShowing = false;
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
        HideClearSaveScreen();
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
    public void HideClearSaveScreen()
    {
        clearSaveDataScrenIsShowing = false;
        clearSaveDataObject.SetActive(false);

        HideChapters();
        gameSettings.HideSettings();

        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(playButton.gameObject);
    }
    public void ShowClearSaveScreen()
    {
        clearSaveDataScrenIsShowing = true;
        clearSaveDataObject.SetActive(true);

        HideChapters();
        gameSettings.HideSettings();

        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(cancleClearSaveDataButton.gameObject);
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
            eventSystem.SetSelectedGameObject(null);
            buttonSound.Play();

            if (gameSettings.settingsIsOn)
            {
                gameSettings.HideSettings();

                eventSystem.SetSelectedGameObject(settingsButton.gameObject);
                settingsButton.Button_Select();
            }
            else if (chaptersIsShowing)
            {
                HideChapters();

                eventSystem.SetSelectedGameObject(playButton.gameObject);
                playButton.Button_Select();
            }
            else if (clearSaveDataScrenIsShowing)
            {
                HideClearSaveScreen();

                eventSystem.SetSelectedGameObject(playButton.gameObject);
                playButton.Button_Select();
            }
        }
    }

    public void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
