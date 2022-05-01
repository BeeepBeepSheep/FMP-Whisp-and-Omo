using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Offset")]
    [SerializeField]
    private int currentShoulderNum;
    [SerializeField]
    private CinemachineCameraOffset camOffset;
    private bool firstTimeToggle = true;

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
        
        camOffset.m_Offset.x = 0;
        currentShoulderNum = 3;
    }

    public void ShoulderToggle(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (firstTimeToggle)
            {
                camOffset.m_Offset.x = -2; // set left
                firstTimeToggle = false;
            }
            else
            {
                //tripple toggle
                currentShoulderNum = (currentShoulderNum % 3) + 1;
                switch (currentShoulderNum)
                {
                    case 1:
                        camOffset.m_Offset.x = 2; // set right
                        break;
                    case 2:
                        camOffset.m_Offset.x = 0; // set centre
                        break;
                    case 3:
                        camOffset.m_Offset.x = -2; // set left
                        break;
                    default:
                        break;
                }
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
                camOffset.m_Offset.x = 0;
            }
           
            if (Physics.Raycast(cam.transform.position, -cam.transform.right, out hit, 2f))
            {
                camOffset.m_Offset.x = 0;
            }
           
        }
    }
}