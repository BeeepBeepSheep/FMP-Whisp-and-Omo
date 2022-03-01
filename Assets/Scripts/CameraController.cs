using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private int currentSHoulderNum = 1;
    [SerializeField]
    private CinemachineCameraOffset camOffset;
    //private CinemachineFreeLook cinemachineFreeLook;

    private void Awake()
    {
        //cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
        camOffset = GetComponent<CinemachineCameraOffset>();
    }

    public void ShoulderToggle(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //tripple toggle
            currentSHoulderNum = (currentSHoulderNum % 3) + 1;
            switch (currentSHoulderNum)
            {
                case 1:
                    camOffset.m_Offset.x = 2;
                    break;
                case 2:
                    camOffset.m_Offset.x = 0;
                    break;
                case 3:
                    camOffset.m_Offset.x = -2;
                    break;
                default:
                    break;
            }
        }
    }
}

