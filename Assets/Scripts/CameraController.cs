using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Offset")]
    [SerializeField]
    private int currentShoulderNum = 3;
    [SerializeField]
    private CinemachineCameraOffset camOffset;
    private float oldOffset = 0f;

    [Header("Collider")]
    private CinemachineCollider cinemachineCollider;
    public float wallCheckTickRate = 0.01f;
    public Camera cam;
    public LayerMask environmentLayer;

    [Header("Look at")]
    public ObjectiveManager objectiveManager;
    public Transform player;
    private CinemachineFreeLook freeLook;
    public CinemachineTargetGroup targetGroup;

    private void Awake()
    {
        camOffset = GetComponent<CinemachineCameraOffset>();
        freeLook = GetComponent<CinemachineFreeLook>();
        cinemachineCollider = GetComponent<CinemachineCollider>();
    }

    void Start()
    {
        freeLook.m_LookAt = targetGroup.transform; ;

        StartCoroutine(CheckWallDistance());

        targetGroup.m_Targets[1].target = player;
        freeLook.m_RecenterToTargetHeading = new AxisState.Recentering(false, 1, 2);
        RecenterCam();
    }

    public void ShoulderToggle(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //tripple toggle
            currentShoulderNum = (currentShoulderNum % 3) + 1;
            switch (currentShoulderNum)
            {
                case 1:
                    camOffset.m_Offset.x = 2;
                    break;
                case 2:
                    RecenterCam();
                    break;
                case 3:
                    camOffset.m_Offset.x = -2;
                    break;
                default:
                    break;
            }
        }
    }
    private void RecenterCam()
    {
        oldOffset = camOffset.m_Offset.x;
        camOffset.m_Offset.x = 0;
    }
    private void RevertToOldOffset()
    {
        camOffset.m_Offset.x = oldOffset;
        Debug.Log("old offset");
    }
    public void FocusToggle(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (targetGroup.m_Targets[1].target == player) // if looking at player
            {
                targetGroup.m_Targets[1].target = objectiveManager.objectives[0]; //most importnat objective will always be at 0
                //enable/ dissable auto recentering
                freeLook.m_RecenterToTargetHeading = new AxisState.Recentering(true, 0f, 0.1f);
                RecenterCam();
            }
            else
            {
                targetGroup.m_Targets[1].target = player;
                freeLook.m_RecenterToTargetHeading = new AxisState.Recentering(false, 0f, 0.1f);
            }
        }
    }
    IEnumerator CheckWallDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(wallCheckTickRate);

            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.right, out hit, 2f))
            {
                RecenterCam();
            }
            if (Physics.Raycast(cam.transform.position, -cam.transform.right, out hit, 2f))
            {
                RecenterCam();
            }
        }
    }
}