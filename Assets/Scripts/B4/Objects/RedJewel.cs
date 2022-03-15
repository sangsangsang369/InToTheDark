using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedJewel : MonoBehaviour
{
    SlotSelectionMng slotSelectMng;
    [HideInInspector] public bool isJewelOnHand = false;

    void Start()
    {
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void RedJewelItem()
    {   
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "붉은보석";
            slotSelectMng.SelectSlot(this.gameObject);
            isJewelOnHand = true;
        }
        else
        {
            slotSelectMng.UnselectSlot(this.gameObject);
            isJewelOnHand = false;
        }
    }
}
