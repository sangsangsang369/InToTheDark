using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B2_Candle : Object
{
    public GameObject candleUI;
    public Text candleText;
    public Text inputTextUI;
    B2_UIManager uiManager;
    private bool playOnce = false;

    void Start()
    {
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    public override void ObjectFunction()
    {
        if (!playOnce)
        {
            candleUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(candleText.text, inputTextUI));
        }
        else
            Debug.Log("이미 읽어본 촛불입니다. 더 없어 그만 눌러");
        
    }
}

