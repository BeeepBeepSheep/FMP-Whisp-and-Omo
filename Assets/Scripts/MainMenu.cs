using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator uiAnim;
    public void StartGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            uiAnim.SetTrigger("StartGame");
        }
    }

    public void LoadChapterOne()
    {
        SceneManager.LoadScene("ChapterOne");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
