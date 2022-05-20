using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public bool gameIsPaused;
    public bool canPause = true;
    [SerializeField] private PlayerInput uiInput;
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private GameObject pauseMenu;
    public GameObject hud;
    [SerializeField] private ButtonLogic resumeButton;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private AudioSource introCutsceneMusic;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] private OmoMovement omoMovement;   
    private bool isFirstTimeUnpause = true;
    [SerializeField] private LevelLoader levelLoader;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        levelLoader.gameObject.SetActive(true);
    }
    void Start()
    {
        isFirstTimeUnpause = true;
        UnPause();
    }
    public void PuaseUnpauseCheck()
    {
        if (canPause)
        {
            if (gameIsPaused)
            {
                UnPause();
                return;
            }
            else
            {
                Puase();
                return;
            }
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
        AudioManager.currantTrack.Pause();
        omoMovement.canJump = false;
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
            isFirstTimeUnpause = false;
            buttonSound.Play();
        }

        if (!playerManager.introCutsceneHasEnded)
        {
            introCutsceneMusic.UnPause();
        }

        if(playerManager.introCutsceneHasEnded)
        {
            omoMovement.canJump = true; // fixes super jump
        }
        AudioManager.currantTrack.UnPause();
    }
    public void PlayButtonSoundPuased()
    {
        Time.timeScale = 1f;
        buttonSound.Play();
        Time.timeScale = 0f;
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        buttonSound.Play();
        gameIsPaused = true;
        StartCoroutine(levelLoader.LoadEsynchronously("MainMenu"));
    }
}
