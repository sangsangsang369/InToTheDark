using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treesap :Object
{
    public GameObject treesapUI;
    public Sprite treesapItemImg;
    public Text treesapText;
    public Text inputTextUI;
    B3UIManager uiManager;
    InventoryMng inventoryMng;
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;

    DataManager data;
    SaveDataClass saveData;
    //public bool isTreesapPicked;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        //isTreesapPicked = saveData.isTreesapPicked;
        if(this.transform.parent.gameObject.layer != 10 && saveData.isTreesapPicked)
        {
            this.gameObject.SetActive(false);
        }

        uiManager = FindObjectOfType<B3UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public override void ObjectFunction()
    {
        treesapUI.SetActive(true);
        uiManager.StartCoroutine(uiManager.LoadTextOneByOne(treesapText.text, inputTextUI));
        GameObject treesap = this.gameObject;
        inventoryMng.PickUp(treesap, 0.4f, ItemClass.ItemPrefabOrder.Sap);
        
        saveData.isTreesapPicked = true;
        data.Save();
    }
    public void TreesapItem()
    {
        if(labtableMng.labTable.activeSelf==false)
        {
            if(slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.itemName = "나무 수액";
                slotSelectMng.SelectSlot(this.gameObject);
            }
            else
            {
                slotSelectMng.UnselectSlot(this.gameObject);
                //treesap_AfterUI.SetActive(true);
                //StartCoroutine(uiManager.LoadTextOneByOne(treesap_AfterText.text, inputTextUI));
            }
        }
        else if(labtableMng.labTable.activeSelf==true) 
        {
            labtableMng.InsertMaterial(this.gameObject);
        }
    }

    public override void ItemActive()
    {
        labtableMng.itemActive["treesapActive"] = true;
    }
    public override void ItemDeactive()
    {
        labtableMng.itemActive["treesapActive"] = false;
    }
}

