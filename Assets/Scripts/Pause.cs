using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private PlayerInput playerInput;

    public bool gameIsPaused;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    void Start()
    {
        //UnPause();
    }
    public void Puase()
    {
        gameIsPaused = true;
        // need to switch input method

        //playerInput.SwitchCurrentActionMap("UI");
        playerInputActions.Player.Disable();
        playerInputActions.UI.Enable();
        Time.timeScale = 0f;
        Debug.Log("gameIsPaused = " + gameIsPaused);

    }
    public void UnPause()
    {
        gameIsPaused = false;
        //playerInput.SwitchCurrentActionMap("Player");
        playerInputActions.Player.Enable();
        playerInputActions.UI.Disable();
        Time.timeScale = 1f;
        Debug.Log("gameIsPaused = " + gameIsPaused);
    }
}
