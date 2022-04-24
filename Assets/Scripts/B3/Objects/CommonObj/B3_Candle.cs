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

    DataManager data;
    SaveDataClass saveData;
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        uiManager = FindObjectOfType<B3UIManager>();

        this.gameObject.GetComponent<BoxCollider2D>().enabled = false; 
    }
    private void Update() 
    {
        if(this.gameObject.GetComponent<BoxCollider2D>().enabled)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false; 
        }
    }
    public override void ObjectFunction()
    {
        candleUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(candleText.text, inputTextUI));
    }
}

