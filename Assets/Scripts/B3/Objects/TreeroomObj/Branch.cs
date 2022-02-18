using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Branch : Object
{ 
    public GameObject branchUI, branch_AfterUI;
    public Sprite branchItemImg;
    public Text branchText, branch_AfterText;
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
        branchUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(branchText.text, inputTextUI));
        GameObject branch = this.gameObject;
        b3inventoryMng.PickUp(branch);
    }
    public void BranchItem()
    {
        if(labtableMng.labTable.activeSelf==false)
        {
            if(slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.SelectSlot(this.gameObject);
            }
            else
            {
                branch_AfterUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(branch_AfterText.text, inputTextUI));
            }  
        }
        else if(labtableMng.labTable.activeSelf==true) 
        {
            labtableMng.InsertMaterial(this.gameObject);
        }
    }

    public override void ItemActive()
    {
        labtableMng.itemActive["branchActive"] = true;
    }
    public override void ItemDeactive()
    {
        labtableMng.itemActive["branchActive"] = false;
    }
}
