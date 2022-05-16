using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonLogic : MonoBehaviour
{
    private TextMeshProUGUI text_TMP;
    [SerializeField] private TMP_FontAsset unHighlightedFont;
    [SerializeField] private TMP_FontAsset highlightedFont;

    public void Button_Select()
    {
        text_TMP.font = highlightedFont;
    }
    public void Button_Deselect()
    {
        text_TMP.font = unHighlightedFont;
    }
}
