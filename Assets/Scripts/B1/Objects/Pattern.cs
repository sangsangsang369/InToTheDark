using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pattern : Object
{
    public GameObject patternUI;
    public Text patternText;
    public Text inputTextUI;
    UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public override void ObjectFunction()
    {
        patternUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(patternText.text, inputTextUI));
    }
}
