using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : Object
{
    public GameObject fruitUI;
     public Sprite fruitItemImg;
    public Text fruitText;
    public Text inputTextUI;
    B3UIManager uiManager;
    InventoryMng inventoryMng;
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;
    FruitMng fruitMng;
    
    DataManager data;
    SaveDataClass saveData;
    SoundManager sound;


    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        sound = SoundManager.inst;

        if(this.transform.parent.gameObject.layer != 10 && saveData.isFruitPicked)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;  //for문 돌면서 배열의 열매 콜라이더 꺼주기
        }
       else
        {
            this.GetComponent<Object>().enabled = false;
            if(this.GetComponent<SpriteRenderer>())
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        uiManager = FindObjectOfType<B3UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        fruitMng = FindObjectOfType<FruitMng>();
    }

    public override void ObjectFunction()
    {
        sound.EffectPlay(sound.leavesShortEffect);
        fruitUI.SetActive(true);
        //uiManager. 추가하니까 되요..근데 왜 되는지는 모르겠는
        uiManager.StartCoroutine(uiManager.LoadTextOneByOne(fruitText.text, inputTextUI));
        
        GameObject fruit = this.gameObject;
        inventoryMng.PickUp(fruit, 0.4f, ItemClass.ItemPrefabOrder.Fruit);

        for(int i=0; i < fruitMng.fruits.Length; i++)  
        //fruit가 클릭되면 프리펩화 되기때문에 childCount에 안 잡힘(childCount=3임)
        //그래서 fruits.length로 해줘야함(start에서 4개 다 저장해주니까)
        {
            //Debug.Log(fruits.Length);
            if(fruitMng.fruits[i] == fruit)
            {
                saveData.fruitNum = i;
                data.Save(); 
            }
        }
        //얘는 그냥 켜져있는거만 콜라이더 끄면 되니까 문제 없을듯
        for(int i=0; i < fruitMng.fruits.Length; i++)  
        {
            fruitMng.fruits[i].GetComponent<BoxCollider2D>().enabled = false;  //for문 돌면서 배열의 열매 콜라이더 꺼주기
        }

        saveData.isFruitPicked = true;
        data.Save();   
    }

    public void FruitItem()
    {
        if(!labtableMng || labtableMng && labtableMng.labTable.activeSelf==false)
        {    
            if(slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.itemName = "나무 열매";
                slotSelectMng.SelectSlot(this.gameObject);
            }
            else
            {
                slotSelectMng.UnselectSlot(this.gameObject);
                //fruit_AfterUI.SetActive(true);
                //StartCoroutine(uiManager.LoadTextOneByOne(fruit_AfterText.text, inputTextUI));
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

}
