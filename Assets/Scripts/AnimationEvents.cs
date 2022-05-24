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
    [SerializeField] private Button creditsExitButton;
    [SerializeField] private Button creditsEnterButton;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Animator creditsAnim;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private GameSettings gameSettings;

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

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            mainMenu.HideChapters();
            gameSettings.HideSettings();

            eventSystem.SetSelectedGameObject(null);
            eventSystem.SetSelectedGameObject(creditsExitButton.gameObject);
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
    }
}
