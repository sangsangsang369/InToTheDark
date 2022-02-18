using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabTable : Object
{
    public GameObject labTableUI, labTableExplainUI;
    public Text labTableText, labTableExplainText;
    public Text inputTextUI;
    B3InventoryMng b3inventoryMng;
    B3UIManager uiManager;
    public GameObject labTableObj; //ui틀면 콜라이더 겹쳐지는 거 땜에 추가

    

    void Start()
    {
        b3inventoryMng = FindObjectOfType<B3InventoryMng>();
        uiManager = FindObjectOfType<B3UIManager>();
    }
    public void LabTableColliderOn() //ui끄면 콜라이더 다시 켜주기
    {
        labTableObj.GetComponent<BoxCollider2D>().enabled = true;
    }
    public override void ObjectFunction()
    {
        labTableUI.SetActive(true);  //실험대 ui 켜기
        if (labTableUI.activeSelf == true)  //실험대 ui 켜지면
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;  //실험대 콜라이더 끄기
            b3inventoryMng.SetInvenSlotBtn_LT(); //인벤토리 기능 제어
        }
           
        labTableExplainUI.SetActive(true);  //실험대 설명 스크립트 on
        StartCoroutine(uiManager.LoadTextOneByOne(labTableExplainText.text, inputTextUI));
    }
}
