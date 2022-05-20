using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class ButtonLogic : MonoBehaviour
{
    private TextMeshProUGUI text_TMP;
    [SerializeField] private TMP_FontAsset unHighlightedFont;
    [SerializeField] private TMP_FontAsset highlightedFont;
    private Animator buttonAnim;

    void Start()
    {
        text_TMP = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        buttonAnim = GetComponent<Animator>();
    }
    public void Button_Select()
    {
        text_TMP.font = highlightedFont;
    }
    public void Button_Deselect()
    {
        text_TMP.font = unHighlightedFont;
    }
}