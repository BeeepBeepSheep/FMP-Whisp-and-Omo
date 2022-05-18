using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public void LoadChapterOne()
    {
        SceneManager.LoadScene("ChapterOne");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
