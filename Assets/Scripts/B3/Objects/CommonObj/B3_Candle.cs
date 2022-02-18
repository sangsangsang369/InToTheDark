using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B3_Candle : Object
{
   public GameObject candleUI;
    public Text candleText;
    public Text inputTextUI;
    B3UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<B3UIManager>();
    }

    public override void ObjectFunction()
    {
        candleUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(candleText.text, inputTextUI));
    }
}

