using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoMemo : Object
{
    B3UIManager uiManager;
    B3InventoryMng b3inventoryMng;
    PianoMng pianoMng;
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;


    void Start()
    {
        uiManager = FindObjectOfType<B3UIManager>();
        b3inventoryMng = FindObjectOfType<B3InventoryMng>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
        pianoMng = FindObjectOfType<PianoMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void PianoMemoItem()
    {
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            pianoMng.pianoMemoUI.SetActive(true); 
        }
    }
}

