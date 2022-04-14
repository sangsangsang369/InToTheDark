using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Candle : Object
{
    public GameObject candleUI;
    public Text candleText;
    public Text inputTextUI;
    UI uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UI>();
    }

    public override void ObjectFunction()
    {
        candleUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(candleText.text, inputTextUI));
    }
}
