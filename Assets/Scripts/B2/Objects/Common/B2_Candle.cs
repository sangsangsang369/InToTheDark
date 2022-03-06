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
    private bool OnB2CandleOnce = false;

    DataManager data;
    SaveDataClass saveData;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        OnB2CandleOnce = saveData.OnB2CandleOnce;
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    public override void ObjectFunction()
    {
        if (!OnB2CandleOnce)
        {
            candleUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(candleText.text, inputTextUI));
            OnB2CandleOnce = true;
            saveData.OnB2CandleOnce = true;
            data.Save();
        }
        else
            Debug.Log("이미 읽어본 촛불입니다. 더 없어 그만 눌러");
        
    }
}

