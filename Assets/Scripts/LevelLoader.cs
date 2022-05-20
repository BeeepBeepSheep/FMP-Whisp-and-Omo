using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Image loadingBar;
    [SerializeField] private TextMeshProUGUI progressPercentage;
    private Animator levelLoaderAnim;
    [SerializeField] private AnimationClip sceneClosingAnimationClip;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Pause pauseScript;

    private void Start()
    {
        levelLoaderAnim = GetComponent<Animator>();
    }
    public IEnumerator LoadEsynchronously(string sceneName)
    {
        levelLoaderAnim.SetTrigger("LoadNewLevel");

        float fadeLength = sceneClosingAnimationClip.length;
        if (SceneManager.GetActiveScene().name == "ChapterOne")
        {
            pauseScript.UnPause();
        }
        yield return new WaitForSeconds(fadeLength);

        audioManager.currantTrack.Pause();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        eventSystem.SetSelectedGameObject(null);
        Time.timeScale = 1;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        //if (SceneManager.GetActiveScene().name == "ChapterOne")
        //{
        //    pauseScript.UnPause();
        //}
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingBar.fillAmount = progress;
            progressPercentage.text = Mathf.RoundToInt(progress * 100) + "%";
            yield return null;
        }
    }
}
