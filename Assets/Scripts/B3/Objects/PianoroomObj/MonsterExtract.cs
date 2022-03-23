using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterExtract :  Object
{
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        labtableMng = FindObjectOfType<LabTableItemManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void MonsterExtractItem()
    {
        if(!labtableMng || labtableMng && labtableMng.labTable.activeSelf==false)
        {
            if(slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.itemName = "이형체의 진액";
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
        labtableMng.itemActive["monsterExtractActive"] = true;
    }
    public override void ItemDeactive()
    {
        labtableMng.itemActive["monsterExtractActive"] = false;
    }

}

