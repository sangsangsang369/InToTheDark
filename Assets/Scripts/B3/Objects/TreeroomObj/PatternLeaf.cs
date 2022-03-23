using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternLeaf : Object
{
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        labtableMng = FindObjectOfType<LabTableItemManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void PatternLeafItem()
    {
        if(!labtableMng || labtableMng && labtableMng.labTable.activeSelf==false)
        {
            if(slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.itemName = "무늬가 생긴 잎";
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
        labtableMng.itemActive["patternLeafActive"] = true;
        //Debug.Log("active");
    }
    public override void ItemDeactive()
    {
        labtableMng.itemActive["patternLeafActive"] = false;
        //Debug.Log("deactive");
    }

}
