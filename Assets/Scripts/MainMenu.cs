using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
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
