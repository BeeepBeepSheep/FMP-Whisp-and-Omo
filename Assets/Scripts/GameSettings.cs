using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using TMPro;

public class GameSettings : MonoBehaviour
{
    [Header("UI")]
    public bool settingsIsOn = false;
    [SerializeField] private GameObject settingsBackground;
    public Button controlsButton;
    public Button videoButton;
    public Button audioButton;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private MainMenu mainMenuScript;

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

    [Header("Video")]
    [SerializeField] private GameObject fullscreen_checkmark;
    private bool isFullscreen;
    [SerializeField] private int curantQuality;
    [SerializeField] private RenderPipelineAsset[] qualityLevels;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private GameObject motionBlur_checkmark;
    [SerializeField] private GameObject motionBlurVolume;

    [SerializeField] private GameObject fps;
    [SerializeField] private GameObject fps_Tick;

    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private int resolutionIndex;
    [SerializeField] List<ResolutionItem> resolutions = new List<ResolutionItem>();

    [Header("Audio")]
    [SerializeField] private AudioMixer masterMixer;
    private float masterVol;
    private float musicVol;
    private float effectsVol;
    private float environmentVol;
    [SerializeField] private Slider masterVol_Slider;
    [SerializeField] private Slider musicVol_Slider;
    [SerializeField] private Slider effectsVol_Slider;
    [SerializeField] private Slider environmentVol_Slider;

    [Header("In Game")]
    [SerializeField] private RectTransform pilar;
    [SerializeField] private float pilarNewPos_X;
    [SerializeField] private float pilarOldPos_X = 0;

    [Header("Chater One Progress")]
    private int chapterOneMainProgress;
    private int chapterOneSideQuestProgress;
    [SerializeField] private TextMeshProUGUI chapterOneMainProgress_text;
    [SerializeField] private TextMeshProUGUI chapterOneSideQuestProgress_text;
    [SerializeField] private string chapterOneProgress_Label = "Progress: ";
    [SerializeField] private string chapterOneSideQuestProgress_Label = "Whisps Freed: ";

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

        resolutionDropdown.value = resolutionIndex;
        ChangeResolution(resolutionIndex);

        GetMotionBlur();
        GetShowFPS();

        curantQuality = PlayerPrefs.GetInt("Quality Level", 2);
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        ChangeQuality(curantQuality);

        SetMasterVol(masterVol);
        SetMusicVol(musicVol);
        SetEffectsVol(effectsVol);
        SetEnvironmentVol(environmentVol);
        masterVol_Slider.value = masterVol;
        musicVol_Slider.value = musicVol;
        effectsVol_Slider.value = effectsVol;
        environmentVol_Slider.value = environmentVol;

        GetChapterOneProgress();

        ShowControlsSettings();
        HideSettings();
    }
    public void ToggleSettings()
    {
        if (settingsIsOn)
        {
            HideSettings();
            return;
        }
        else
        {
            ShowSettings();
            return;
        }
    }
    public void ShowSettings()
    {
        settingsIsOn = true;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(controlsButton.gameObject);
        settingsBackground.SetActive(true);

        if (SceneManager.GetActiveScene().name != "MainMenu")//if in level
        {
            pilar.localPosition = new Vector3(pilarNewPos_X, 0, 0);
        }
    }
    public void HideSettings()
    {
        settingsIsOn = false;
        settingsBackground.SetActive(false);
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            pilar.localPosition = new Vector3(pilarOldPos_X, 0, 0);
        }
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
            isFullscreen = false;
            Screen.fullScreen = false;
            return false;
        }
        else
        {
            fullscreen_checkmark.SetActive(true);
            isFullscreen = true;
            Screen.fullScreen = true;
            return true;
        }
    }
    public void ChangeResolution(int newResolutionIndex)
    {
        resolutionIndex = PlayerPrefs.GetInt("Currant Resolution Index", 1);
        Screen.SetResolution(resolutions[newResolutionIndex].horizontal, resolutions[newResolutionIndex].virtocle, isFullscreen);

        PlayerPrefs.SetInt("Currant Resolution Index", newResolutionIndex);
    }
    public void ChangeQuality(int value)
    {
        curantQuality = PlayerPrefs.GetInt("Quality Level", 2);
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = qualityLevels[value];

        PlayerPrefs.SetInt("Quality Level", value);
    }
    private bool GetMotionBlur()
    {
        if (PlayerPrefs.GetInt("MotionBlur", 1) == 0) // if 0 false, if 1 true
        {
            motionBlur_checkmark.SetActive(false);

            motionBlurVolume.SetActive(false);
            return false;
        }
        else
        {
            motionBlur_checkmark.SetActive(true);
            motionBlurVolume.SetActive(true);
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
    public void ToggleMotionBlur()
    {
        if (GetMotionBlur()) // if motionblur is on
        {
            PlayerPrefs.SetInt("MotionBlur", 0);
            GetMotionBlur(); // inverted true to false
        }
        else
        {
            PlayerPrefs.SetInt("MotionBlur", 1);
            GetMotionBlur(); // inverted false to true
        }
    }
    public void SetMasterVol(float newValue)
    {
        masterVol = PlayerPrefs.GetFloat("MasterVol", -25);

        PlayerPrefs.SetFloat("MasterVol", newValue);
        masterMixer.SetFloat("MasterVol", newValue);
    }
    public void SetMusicVol(float newValue)
    {
        musicVol = PlayerPrefs.GetFloat("MusicVol", 0);

        PlayerPrefs.SetFloat("MusicVol", newValue);
        masterMixer.SetFloat("MusicVol", newValue);
    }
    public void SetEffectsVol(float newValue)
    {
        effectsVol = PlayerPrefs.GetFloat("EffectsVol", 0);

        PlayerPrefs.SetFloat("EffectsVol", newValue);
        masterMixer.SetFloat("EffectsVol", newValue);
    }
    public void SetEnvironmentVol(float newValue)
    {
        environmentVol = PlayerPrefs.GetFloat("EnvironmentVol", 0);

        PlayerPrefs.SetFloat("EnvironmentVol", newValue);
        masterMixer.SetFloat("EnvironmentVol", newValue);
    }
    private void GetChapterOneProgress()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            chapterOneMainProgress = PlayerPrefs.GetInt("Chapter One Main Progress", 0);
            chapterOneSideQuestProgress = PlayerPrefs.GetInt("Chapter One SideQuestProgress", 0);

            chapterOneMainProgress_text.text = chapterOneProgress_Label + chapterOneMainProgress.ToString() + "%";
            chapterOneSideQuestProgress_text.text = chapterOneSideQuestProgress_Label + chapterOneSideQuestProgress.ToString() + "/5";
        }
    }
    private bool GetShowFPS()
    {
        if (PlayerPrefs.GetInt("Show FPS", 0) == 0) // if 0 false, if 1 true
        {
            fps.SetActive(false);
            fps_Tick.SetActive(false);
            return false;
        }
        else
        {
            fps.SetActive(true);
            fps_Tick.SetActive(true);
            return true;
        }

    }
    public void ToggleFPS()
    {
        if (GetShowFPS()) // if motionblur is on
        {
            PlayerPrefs.SetInt("Show FPS", 0);
            GetShowFPS(); // inverted true to false
        }
        else
        {
            PlayerPrefs.SetInt("Show FPS", 1);
            GetShowFPS(); // inverted false to true
        }
    }
    public void SetChapter_Main_Progress(int newValue)
    {
        PlayerPrefs.SetInt("Chapter One Main Progress", newValue);
    }
    public void SetChapterOne_Sidequest_Progress(int newValue)
    {
        PlayerPrefs.SetInt("Chapter One SideQuestProgress", newValue);
    }
}

[System.Serializable]
public class ResolutionItem
{
    public int horizontal;
    public int virtocle;
}