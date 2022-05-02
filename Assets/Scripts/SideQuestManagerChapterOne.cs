using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideQuestManagerChapterOne : MonoBehaviour
{
    [SerializeField] private Animator uiAnim;
    [SerializeField] private int whispsFreed = 0;
    [SerializeField] private Transform[] uiCounts;

    public void IncreaseFreedCount()
    {
        if (whispsFreed <= uiCounts.Length)
        {
            whispsFreed++;

            if (whispsFreed == 1)
            {
                uiAnim.SetTrigger("ActivateSidequest");
            }

            foreach (Transform uiCount in uiCounts)
            {
                uiCount.gameObject.SetActive(false);
            }

            switch (whispsFreed)
            {
                case 1:
                    uiCounts[0].gameObject.SetActive(true);
                    break;
                case 2:
                    uiCounts[1].gameObject.SetActive(true);
                    break;
                case 3:
                    uiCounts[2].gameObject.SetActive(true);
                    break;
                case 4:
                    uiCounts[3].gameObject.SetActive(true);
                    break;
                case 5:
                    uiCounts[4].gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}
