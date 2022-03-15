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
    private bool OnB3CandleOnce = false;

    DataManager data;
    SaveDataClass saveData;
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        OnB3CandleOnce = saveData.OnB3CandleOnce;
        uiManager = FindObjectOfType<B3UIManager>();
        if(OnB3CandleOnce)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false; 
        }
    }
    private void Update() 
    {
        if(OnB3CandleOnce && this.gameObject.GetComponent<BoxCollider2D>().enabled)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false; 
        }
    }
    public override void ObjectFunction()
    {
        if (!OnB3CandleOnce)
        {
            candleUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(candleText.text, inputTextUI));
            OnB3CandleOnce = true;
            saveData.OnB3CandleOnce = true;
            data.Save();
        }
    }
}

