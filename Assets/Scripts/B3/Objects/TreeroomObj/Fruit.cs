using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : Object
{
    public GameObject fruitUI, fruit_AfterUI;
     public Sprite fruitItemImg;
    public Text fruitText, fruit_AfterText;
    public Text inputTextUI;
    B3UIManager uiManager;
    InventoryMng inventoryMng;
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;
    
    public GameObject fruitGroup;
    public GameObject[] fruits;
    
    DataManager data;
    SaveDataClass saveData;


    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;

        if(this.transform.parent.gameObject.layer != 10 && saveData.isFruitPicked)
        {
            fruits[saveData.fruitNum].SetActive(false);
            for(int i=0; i < fruitGroup.transform.childCount; i++)  
            {
                fruits[i].GetComponent<BoxCollider2D>().enabled = false;  //for문 돌면서 배열의 열매 콜라이더 꺼주기
            }
        }
        else if(this.transform.parent.gameObject.layer != 10 && !saveData.isFruitPicked)
        {
            fruits= GetChildren(fruitGroup);  //TreeroomFruit에 있는 열매 오브젝트를 배열로
        }

        uiManager = FindObjectOfType<B3UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public override void ObjectFunction()
    {
        fruitUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(fruitText.text, inputTextUI));
        
        GameObject fruit = this.gameObject;
        inventoryMng.PickUp(fruit, 0.4f, ItemClass.ItemPrefabOrder.Fruit);

        for(int i=0; i < fruits.Length; i++)  
        //fruit가 클릭되면 프리펩화 되기때문에 childCount에 안 잡힘(childCount=3임)
        //그래서 fruits.length로 해줘야함(start에서 4개 다 저장해주니까)
        {
            //Debug.Log(fruits.Length);
            if(fruits[i] == fruit)
            {
                saveData.fruitNum = i;
                data.Save(); 
            }
        }
        //얘는 그냥 켜져있는거만 콜라이더 끄면 되니까 문제 없을듯
        for(int i=0; i < fruitGroup.transform.childCount; i++)  
        {
            fruits[i].GetComponent<BoxCollider2D>().enabled = false;  //for문 돌면서 배열의 열매 콜라이더 꺼주기
        }

        saveData.isFruitPicked = true;
        data.Save();   
    }

    public void FruitItem()
    {
        if(labtableMng.labTable.activeSelf==false)
        {    
            if(slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.SelectSlot(this.gameObject);
            }
            else
            {
                fruit_AfterUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(fruit_AfterText.text, inputTextUI));
            }
        }
        else if(labtableMng.labTable.activeSelf==true) 
        {
            
            labtableMng.InsertMaterial(this.gameObject);
        }
    }

    public override void ItemActive()
    {
        labtableMng.itemActive["fruitActive"] = true;
    }
    public override void ItemDeactive()
    {
        labtableMng.itemActive["fruitActive"] = false;
    }

    public GameObject[] GetChildren(GameObject parent) //게임오브젝트의 자식들 배열로 만드는 함수
    {
        GameObject[] children = new GameObject[parent.transform.childCount];

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            children[i] = parent.transform.GetChild(i).gameObject;
        }

        return children;
    }
}
