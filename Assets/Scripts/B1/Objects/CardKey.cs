using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardKey : MonoBehaviour
{
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void CardKeyItem()
    {   
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "실험실 카드키";
            slotSelectMng.SelectSlot(this.gameObject);
            slotSelectMng.usableItem = "cardKeySelected";
            
        }
        else
        {
            slotSelectMng.UnselectSlot(this.gameObject);
        }
    }
}
