using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoMemo : Object
{
    UI uiManager;
    PianoMng pianoMng;
    LabTableItemManager labtableMng;
    SlotSelectionMng slotSelectMng;
    public GameObject pianoMemoUI;

    void Start()
    {
        uiManager = FindObjectOfType<UI>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
        pianoMng = FindObjectOfType<PianoMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void PianoMemoItem()
    {
        if(pianoMemoUI.transform.parent == this.transform)
        {
            pianoMemoUI.transform.SetParent(this.transform.parent.parent.parent.parent, false);
        }
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "악보가 적힌 쪽지";
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            pianoMemoUI.SetActive(true); 
        }
    }

}

