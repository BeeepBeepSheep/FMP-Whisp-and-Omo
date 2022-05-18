using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public bool gameIsPaused;
    [SerializeField] private PlayerInput uiInput;
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject hud;
    [SerializeField] private ButtonLogic resumeButton;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private AudioSource introCutsceneMusic;
    private bool isFirstTimeUnpause = true;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    void Start()
    {
        isFirstTimeUnpause = true;
        UnPause();
    }
    public void PuaseUnpauseCheck()
    {
        if (gameIsPaused)
        {
            UnPause();
        }
        else
        {
            Puase();
        }
    }
    public void Puase()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameIsPaused = true;
        pauseMenu.SetActive(true);
        hud.SetActive(false);

        resumeButton.Button_Select();

        Time.timeScale = 0f;

        if (!playerManager.introCutsceneHasEnded)
        {
            introCutsceneMusic.Pause();
        }
    }
    public void UnPause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gameIsPaused = false;
        pauseMenu.SetActive(false);
        hud.SetActive(true);

        Time.timeScale = 1f;

        if (!isFirstTimeUnpause)
        {
            buttonSound.Play();
            isFirstTimeUnpause = false;
        }

        if (!playerManager.introCutsceneHasEnded)
        {
            introCutsceneMusic.UnPause();
        }
    }
    public void PlayButtonSoundPuased()
    {
        Time.timeScale = 1f;
        buttonSound.Play();
        Time.timeScale = 0f;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
