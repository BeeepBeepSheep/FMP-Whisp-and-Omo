using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }
    public void LoadChapterOne()
    {
        StartCoroutine(levelLoader.LoadEsynchronously("ChapterOne"));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
