using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoMemo : Object
{
    B3UIManager uiManager;
    PianoMng pianoMng;
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;


    void Start()
    {
        uiManager = FindObjectOfType<B3UIManager>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
        pianoMng = FindObjectOfType<PianoMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void PianoMemoItem()
    {
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "악보가 적힌 쪽지";
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            pianoMng.pianoMemoUI.SetActive(true); 
        }
    }

}

