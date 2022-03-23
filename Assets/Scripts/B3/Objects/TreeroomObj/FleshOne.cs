using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FleshOne : Object
{
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        labtableMng = FindObjectOfType<LabTableItemManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void FleshOneItem()
    {
        if(!labtableMng || labtableMng && labtableMng.labTable.activeSelf==false)
        {
            if(slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.itemName = "살덩어리1";
                slotSelectMng.SelectSlot(this.gameObject);
            }
            else
            {
                slotSelectMng.UnselectSlot(this.gameObject);
            } 
        }
        else if(labtableMng.labTable.activeSelf==true) 
        {
            labtableMng.InsertMaterial(this.gameObject);
        }
    }

    public override void ItemActive()
    {
        labtableMng.itemActive["fleshOneActive"] = true;
    }
    public override void ItemDeactive()
    {
        labtableMng.itemActive["fleshOneActive"] = false;
    }
}
