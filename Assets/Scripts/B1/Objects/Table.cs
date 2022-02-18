using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : Object
{
    public GameObject tableUI;
    public GameObject diaryUI;
    public List<Text> diaryTexts;
    public Text inputTextUI;
    UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public override void ObjectFunction()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!uiManager.isUnlocked)
            {
                tableUI.SetActive(true);
                StartCoroutine(uiManager.LoadTexts(diaryTexts, inputTextUI, 2));
            }
            else
            {
                diaryUI.SetActive(true);
            }
        }
    }
}
