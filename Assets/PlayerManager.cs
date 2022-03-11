using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private OmoMovement omoMovement;
    [SerializeField] private OmoAnimationController omoAnimationController;
    [SerializeField] private WhispOrbitController whispOrbitController;
    [SerializeField] private WhispFollow whispFollow;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private ObjectiveManager objectiveManager;

    private void Awake()
    {
        Instance = this;
    }

    public void Activate()
    {
        omoMovement.enabled = true;
        omoAnimationController.enabled = true;
        whispOrbitController.enabled = true;
        whispFollow.enabled = true;
        cameraController.enabled = true;
        objectiveManager.enabled = true;
    }
    public void Deactivate()
    {
        omoMovement.enabled = false;
        omoAnimationController.enabled = false;
        whispOrbitController.enabled = false;
        whispFollow.enabled = false;
        cameraController.enabled = false;
        objectiveManager.enabled = false;
    }
}
