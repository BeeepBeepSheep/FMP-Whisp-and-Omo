using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private EventSystem eventSystem;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        levelLoader.gameObject.SetActive(true);
    }
    public void LoadChapterOne()
    {
        StartCoroutine(levelLoader.LoadEsynchronously("ChapterOne"));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    //public void GenericSelectRight()
    //{
    //    Debug.Log("genericRight");
    //    if(!gameSettings.settingsIsOn)
    //    {
    //        eventSystem.SetSelectedGameObject(null);
    //        eventSystem.SetSelectedGameObject(playButton.gameObject);
    //    }
    //    else if (gameSettings.settingsIsOn)
    //    {
    //        switch (gameSettings.selectedIndex)
    //        {
    //            case 1:
    //                eventSystem.SetSelectedGameObject(null);
    //                eventSystem.SetSelectedGameObject(gameSettings.controlsButton.gameObject);
    //                break;
    //            case 2:
    //                eventSystem.SetSelectedGameObject(null);
    //                eventSystem.SetSelectedGameObject(gameSettings.videoButton.gameObject);
    //                break;
    //            case 3:
    //                eventSystem.SetSelectedGameObject(null);
    //                eventSystem.SetSelectedGameObject(gameSettings.audioButton.gameObject);
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}
}
