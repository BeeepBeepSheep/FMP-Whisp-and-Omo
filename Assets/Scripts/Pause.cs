using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public bool gameIsPaused;
    [SerializeField] private PlayerInput uiInput;
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button firstButton;

    private void Awake()
    {

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    void Start()
    {
        UnPause();
    }
    public void PuaseUnpauseCheck()
    {
        if(gameIsPaused)
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

        firstButton.Select();
        // need to switch input method

        //playerInput.SwitchCurrentActionMap("UI");
        //playerInputActions.Player.Disable();
        //playerInputActions.UI.Enable();

        Time.timeScale = 0f;
        Debug.Log("gameIsPaused = " + gameIsPaused);
    }
    public void UnPause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gameIsPaused = false;
        pauseMenu.SetActive(false);

        //playerInput.SwitchCurrentActionMap("Player");
        //playerInputActions.Player.Enable();
        //playerInputActions.UI.Disable();

        Time.timeScale = 1f;
        Debug.Log("gameIsPaused = " + gameIsPaused);
    }
}
