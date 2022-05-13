using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonLogic : MonoBehaviour
{
    private TextMeshProUGUI text_TMP;
    [SerializeField] private TMP_FontAsset unHighlightedFont;
    [SerializeField] private TMP_FontAsset highlightedFont;

    private void Start()
    {
        text_TMP = GetComponentInChildren(typeof(TextMeshProUGUI), true) as TextMeshProUGUI;
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
