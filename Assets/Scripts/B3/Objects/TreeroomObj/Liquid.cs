using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Liquid : Object
{
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        labtableMng = FindObjectOfType<LabTableItemManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void LiquidItem()
    {
        if(!labtableMng || labtableMng && labtableMng.labTable.activeSelf==false)
        {
            if(slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.itemName = "투명한 액체";
                slotSelectMng.SelectSlot(this.gameObject);
                slotSelectMng.usableItem = "liquidSelected";
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
        labtableMng.itemActive["liquidActive"] = true;
    }
    public override void ItemDeactive()
    {
        labtableMng.itemActive["liquidActive"] = false;
    }

}
