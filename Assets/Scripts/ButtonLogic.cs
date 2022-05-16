using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonLogic : MonoBehaviour
{
    private TextMeshProUGUI text_TMP;
    [SerializeField] private TMP_FontAsset unHighlightedFont;
    [SerializeField] private TMP_FontAsset highlightedFont;

    void Start()
    {
        text_TMP = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void Button_Select()
    {
        Debug.Log("select");
        text_TMP.font = highlightedFont;
    }
    public void Button_Deselect()
    {
        Debug.Log("deselect");
        text_TMP.font = unHighlightedFont;
    }
}