using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private PostProccessingManager postProccessingManager;
    [SerializeField] private PlayerManager playerManager;

    [Header("credits only")]
    [SerializeField] private Button creditsExitButton;
    [SerializeField] private Button creditsEnterButton;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Animator creditsAnim;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private Pause pauseScript;

    public void ToggleOutsidePostProccessing()
    {
        postProccessingManager.ToggleOutside();
    }
    public void DeactivatePlayer()
    {
        playerManager.DeactivateOutro();
    }
    public void SkipCutscene()
    {
        playerManager.SkipCutscene();
    }
    public void EnterCredits()
    {
        creditsAnim.SetBool("CreditsShouldPlay", true);

        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(creditsExitButton.gameObject);
        gameSettings.HideSettings();

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            mainMenu.HideChapters();
        }
        else if (SceneManager.GetActiveScene().name == "ChapterOne")
        {
            pauseScript.canPause = false;
        }
    }
    public void ExitCredits()
    {
        creditsAnim.SetBool("CreditsShouldPlay", false);

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            mainMenu.HideChapters();
            gameSettings.HideSettings();
            eventSystem.SetSelectedGameObject(null);
            eventSystem.SetSelectedGameObject(creditsEnterButton.gameObject);
        }
        else
        {
            pauseScript.LoadMainMenu();
        }
    }
}