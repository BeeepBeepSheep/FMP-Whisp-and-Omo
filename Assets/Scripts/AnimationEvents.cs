using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private PostProccessingManager postProccessingManager;
    [SerializeField] private PlayerManager playerManager;

    public void ToggleOutsidePostProccessing()
    {
        postProccessingManager.ToggleOutside();
    }
    public void DeactivatePlayer()
    {
        playerManager.Deactivate();
    }
}
