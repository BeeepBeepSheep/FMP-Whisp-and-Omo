using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
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
