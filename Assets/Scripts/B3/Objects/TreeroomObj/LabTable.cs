using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabTable : Object
{
    public GameObject labTableUI, labTableExplainUI;
    public Text labTableText, labTableExplainText;
    public Text inputTextUI;
    LabTableItemManager labtableMng;
    B3UIManager uiManager;
    public GameObject labTableObj; //ui틀면 콜라이더 겹쳐지는 거 땜에 추가

    DataManager data;
    SaveDataClass saveData;
    public bool isLabTableReEntered;
    public bool isLabTableOn;

    void Start()
    {
        labtableMng = FindObjectOfType<LabTableItemManager>();
        uiManager = FindObjectOfType<B3UIManager>();

        data = DataManager.singleTon;
        saveData = data.saveData;
        isLabTableReEntered = saveData.isLabTableReEntered;
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
            labtableMng.SetInvenSlotBtn_LT(); //인벤토리 기능 제어
        }
        if(isLabTableReEntered == false) 
        {   
            labTableExplainUI.SetActive(true);  //실험대 설명 스크립트 on
            StartCoroutine(uiManager.LoadTextOneByOne(labTableExplainText.text, inputTextUI));
            isLabTableReEntered = true;
            saveData.isLabTableReEntered = true;
            data.Save();
        }
    }
}
