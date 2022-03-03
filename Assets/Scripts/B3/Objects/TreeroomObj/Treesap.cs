using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treesap :Object
{
    public GameObject treesapUI, treesap_AfterUI;
    public Sprite treesapItemImg;
    public Text treesapText, treesap_AfterText;
    public Text inputTextUI;
    B3UIManager uiManager;
    InventoryMng inventoryMng;
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        if(this.transform.parent.gameObject.layer != 10 /*&& 이미 주워졌으면*/)
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
        StartCoroutine(uiManager.LoadTextOneByOne(treesapText.text, inputTextUI));
        GameObject treesap = this.gameObject;
        inventoryMng.PickUp(treesap, 0.4f);
    }
    public void TreesapItem()
    {
        if(labtableMng.labTable.activeSelf==false)
        {
            if(slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.SelectSlot(this.gameObject);
            }
            else
            {
                treesap_AfterUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(treesap_AfterText.text, inputTextUI));
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

