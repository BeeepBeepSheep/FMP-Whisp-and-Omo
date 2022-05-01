using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private PostProccessingManager postProccessingManager;

    public void ToggleOutsidePostProccessing()
    {
        postProccessingManager.ToggleOutside();
    }
}
