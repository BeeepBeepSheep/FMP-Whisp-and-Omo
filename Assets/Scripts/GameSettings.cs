using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [Header("UI")]
    public bool settingsIsOn = false;
    [SerializeField] private GameObject settingsBackground;
    public Button controlsButton;
    public Button videoButton;
    public Button audioButton;
    [SerializeField] private EventSystem eventSystem;

    [Header("Sections")]
    [HideInInspector] public int selectedIndex; // 1 = contols, 2 = video, 3 = audio
    [SerializeField] private GameObject controlsSettings;
    [SerializeField] private GameObject videoSettings;
    [SerializeField] private GameObject audioSettings;

    [Header("Sensitivity")]
    [SerializeField] private Slider sensSlider_X;
    [SerializeField] private Slider sensSlider_Y;
    [SerializeField] private int sensX_value;
    [SerializeField] private int sensY_value; // stage in array
    [SerializeField] private float[] sensesArray_X; // for each stage set sensitivity
    [SerializeField] private float[] sensesArray_Y;

    [Header("-------------")]
    [SerializeField] private CinemachineFreeLook cinemachinceFreelookCam;

    [Header("Invert")]
    [SerializeField] private GameObject invert_X_Button_checkmark;
    [SerializeField] private GameObject invert_Y_Button_checkmark;

    [Header("Fullscreen")]
    [SerializeField] private GameObject fullscreen_checkmark;

    void Start()
    {
        settingsBackground.SetActive(false);

        sensX_value = PlayerPrefs.GetInt("Sensitivity X", 3);
        sensY_value = PlayerPrefs.GetInt("Sensitivity Y", 3);

        SetSensitivity_X(sensX_value);
        SetSensitivity_Y(sensY_value);

        GetInvert_X_Axis();
        GetInvert_Y_Axis();

        GetFullscreen();

        ShowControlsSettings();
    }
    public void ToggleSettings()
    {
        if (settingsIsOn)
        {
            HideSettings();
            settingsIsOn = false;
            return;
        }
        else
        {
            ShowSettings();
            settingsIsOn = true;
            return;
        }
    }
    public void ShowSettings()
    {
        settingsBackground.SetActive(true);
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(controlsButton.gameObject);
    }
    public void HideSettings()
    {
        settingsBackground.SetActive(false);
    }

    public void ShowControlsSettings()
    {
        //sensitivity
        sensX_value = PlayerPrefs.GetInt("Sensitivity X");
        sensY_value = PlayerPrefs.GetInt("Sensitivity Y");
        
        sensSlider_X.value = sensX_value;
        sensSlider_Y.value = sensY_value;

        //invert
        GetInvert_X_Axis();
        GetInvert_Y_Axis();

        //main
        controlsSettings.SetActive(true);
        videoSettings.SetActive(false);
        audioSettings.SetActive(false);
        selectedIndex = 1;
    }
    public void ShowVideoSettings()
    {
        controlsSettings.SetActive(false);
        videoSettings.SetActive(true);
        audioSettings.SetActive(false);
        selectedIndex = 2;
    }
    public void ShowAudioSettings()
    {
        controlsSettings.SetActive(false);
        videoSettings.SetActive(false);
        audioSettings.SetActive(true);
        selectedIndex = 3;
    }

    public void SetSensitivity_X(float selectedSenseFloat)
    {
        sensX_value = Mathf.RoundToInt(selectedSenseFloat);

        if (SceneManager.GetActiveScene().name != "MainMenu") //if in any chapter
        {
            cinemachinceFreelookCam.m_XAxis.m_MaxSpeed = sensesArray_X[sensX_value]; ;
        }

        sensSlider_X.value = sensX_value;
        PlayerPrefs.SetInt("Sensitivity X", sensX_value);
    }
    public void SetSensitivity_Y(float selectedSenseFloat)
    {
        sensY_value = Mathf.RoundToInt(selectedSenseFloat);

        if (SceneManager.GetActiveScene().name != "MainMenu") //if in any chapter
        {
            cinemachinceFreelookCam.m_YAxis.m_MaxSpeed = sensesArray_Y[sensY_value]; ;
        }

        sensSlider_Y.value = sensY_value;
        PlayerPrefs.SetInt("Sensitivity Y", sensY_value);
    }

    private bool GetInvert_X_Axis()
    {
        if (PlayerPrefs.GetInt("Invert X Axis", 0) == 0) // if 0 false, if 1 true
        {
            if (SceneManager.GetActiveScene().name != "MainMenu") //if in any chapter
            {
                cinemachinceFreelookCam.m_XAxis.m_InvertInput = false;
            }
            invert_X_Button_checkmark.SetActive(false);
            return false;
        }
        else
        {
            if (SceneManager.GetActiveScene().name != "MainMenu") //if in any chapter
            {
                cinemachinceFreelookCam.m_XAxis.m_InvertInput = false;
            }
            invert_X_Button_checkmark.SetActive(true);
            return true;
        }
    }
    private bool GetInvert_Y_Axis()
    {
        if (PlayerPrefs.GetInt("Invert Y Axis", 1) == 0) // if 0 false, if 1 true
        {
            if (SceneManager.GetActiveScene().name != "MainMenu") //if in any chapter
            {
                cinemachinceFreelookCam.m_YAxis.m_InvertInput = false;
            }
            invert_Y_Button_checkmark.SetActive(false);
            return false;
        }
        else
        {
            if (SceneManager.GetActiveScene().name != "MainMenu") //if in any chapter
            {
                cinemachinceFreelookCam.m_YAxis.m_InvertInput = true;
            }
            invert_Y_Button_checkmark.SetActive(true);
            return true;
        }
    }
    public void ToggleInvert_X_Axis()
    {
        if (GetInvert_X_Axis())
        {
            PlayerPrefs.SetInt("Invert X Axis", 0);
            GetInvert_X_Axis(); // inverted true to false
        }
        else
        {
            PlayerPrefs.SetInt("Invert X Axis", 1);
            GetInvert_X_Axis(); // inverted false to true
        }
    }
    public void ToggleInvert_Y_Axis()
    {
        if (GetInvert_Y_Axis())
        {
            PlayerPrefs.SetInt("Invert Y Axis", 0);
            GetInvert_Y_Axis(); // inverted true to false
        }
        else
        {
            PlayerPrefs.SetInt("Invert Y Axis", 1);
            GetInvert_Y_Axis(); // inverted false to true
        }
    }

    private bool GetFullscreen()
    {
        if (PlayerPrefs.GetInt("Fullscreen", 1) == 0) // if 0 false, if 1 true
        {
            fullscreen_checkmark.SetActive(false);
            Screen.fullScreen = false;
            return false;
        }
        else
        {
            fullscreen_checkmark.SetActive(true);
            Screen.fullScreen = true;
            return true;
        }
    }
    public void ToggleFullScreen()
    {
        if (GetFullscreen()) // if fullscreen
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
            GetFullscreen(); // inverted true to false
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
            GetFullscreen(); // inverted false to true
        }
    }
    public void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}