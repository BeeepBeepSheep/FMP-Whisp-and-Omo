using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private WhispFollow whispFollowScript;
    [SerializeField] private Pause pauseScript;
    [SerializeField] private ButtonLogic mainMenuGameOverButton;
    [SerializeField] private EventSystem eventSystem;
    public void TeleportWhisp()
    {
        whispFollowScript.TeleportToOmo();
    }
    public void ChapterOneComplete()
    {
        pauseScript.canPause = false;
        pauseScript.hud.SetActive(false);

        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(mainMenuGameOverButton.gameObject);
        mainMenuGameOverButton.Button_Select();
    }
}
