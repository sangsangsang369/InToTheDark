using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaf : Object
{
    public GameObject leafUI, leaf_AfterUI;
    public Sprite leafItemImg;
    public Text leafText, leaf_AfterText;
    public Text inputTextUI;
    B3UIManager uiManager;
    InventoryMng inventoryMng;
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;


    void Start()
    {
        uiManager = FindObjectOfType<B3UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();

    }

    public override void ObjectFunction()
    {
        leafUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(leafText.text, inputTextUI));
        GameObject leaf = this.gameObject;
        inventoryMng.PickUp(leaf, 0.4f);
    }
    public void LeafItem()
    {
        if(labtableMng.labTable.activeSelf==false)
        {
            if(slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.SelectSlot(this.gameObject);
            }
            else
            {
                leaf_AfterUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(leaf_AfterText.text, inputTextUI));
            }
        }
        else if(labtableMng.labTable.activeSelf==true) 
        {
            labtableMng.InsertMaterial(this.gameObject);
        }
    }

    public override void ItemActive()
    {
        labtableMng.itemActive["leafActive"] = true;
    }
    public override void ItemDeactive()
    {
        labtableMng.itemActive["leafActive"] = false;
    }
}

