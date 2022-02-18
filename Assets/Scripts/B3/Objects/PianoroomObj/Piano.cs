using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piano : Object
{
    public GameObject pianoUI, pianoExplainUI;
    public Text pianoExplainText;
    public Text inputTextUI;
    B3UIManager uiManager;
    B3InventoryMng b3inventoryMng;
    public GameObject pianoMemoItem;
    int FirstClickCount = 1;
    

    void Start()
    {
        uiManager = FindObjectOfType<B3UIManager>();
        b3inventoryMng = FindObjectOfType<B3InventoryMng>();
    }

    public override void ObjectFunction()
    {
        pianoUI.SetActive(true);  //피아노 ui 켜기
        if (pianoUI.activeSelf == true)  //피아노 ui 켜지면
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;  //피아노 콜라이더 끄기
        }

        if(FirstClickCount == 1)
        {
            FirstClickCount++;
            pianoExplainUI.SetActive(true);  //설명 스크립트 on
            StartCoroutine(uiManager.LoadTextOneByOne(pianoExplainText.text, inputTextUI));
            b3inventoryMng.AutoPickUp(pianoMemoItem);
        }   
        
    }
}

