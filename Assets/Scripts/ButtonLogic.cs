using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonLogic : MonoBehaviour
{
    private TextMeshProUGUI text_TMP;
    [SerializeField] private TMP_FontAsset unHighlightedFont;
    [SerializeField] private TMP_FontAsset highlightedFont;
    [SerializeField] private bool isFirstSelected = false;
    [SerializeField] private EventSystem myEventSystem;

    void Start()
    {
        text_TMP = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        //GetComponent<Animator>().SetTrigger("Selected");
    }
    void OnEnable()
    {
        if (isFirstSelected)
        {
            myEventSystem.SetSelectedGameObject(null);
            GetComponent<Button>().Select();
            GetComponent<Animator>().SetTrigger("Selected");
            Button_Select();
        }
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