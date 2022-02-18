﻿using System.Collections;
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
    B3InventoryMng b3inventoryMng;
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        uiManager = FindObjectOfType<B3UIManager>();
        b3inventoryMng = FindObjectOfType<B3InventoryMng>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public override void ObjectFunction()
    {
        treesapUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(treesapText.text, inputTextUI));
        GameObject treesap = this.gameObject;
        b3inventoryMng.PickUp(treesap);
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

