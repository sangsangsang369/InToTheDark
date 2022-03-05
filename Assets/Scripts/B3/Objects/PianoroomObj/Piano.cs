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
    InventoryMng inventoryMng;
    public GameObject pianoMemoItem;
    
    DataManager data;
    SaveDataClass saveData;
    public bool isPianoMemoGained;
    

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        isPianoMemoGained = saveData.isPianoMemoGained;

        uiManager = FindObjectOfType<B3UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
    }

    public override void ObjectFunction()
    {
        pianoUI.SetActive(true);  //피아노 ui 켜기
        if (pianoUI.activeSelf == true)  //피아노 ui 켜지면
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;  //피아노 콜라이더 끄기
        }
        //피아노 최초로 클릭할 때
        if(isPianoMemoGained == false)
        {
            pianoExplainUI.SetActive(true);  //설명 스크립트 on
            StartCoroutine(uiManager.LoadTextOneByOne(pianoExplainText.text, inputTextUI));
            //피아노 메모 획득
            inventoryMng.AddToInventory(pianoMemoItem, 0.4f, ItemClass.ItemPrefabOrder.PianoMemo);
            
            isPianoMemoGained = true;
            saveData.isPianoMemoGained = true;
            data.Save();
        }     
    }
}

