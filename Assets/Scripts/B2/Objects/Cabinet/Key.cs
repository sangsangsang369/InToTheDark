using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Object
{
    SlotSelectionMng slotSelectMng;

    // Start is called before the first frame update
    void Start()
    {
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    // Update is called once per frame
    public void UseCardkey()
    {
        if (slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "캐비닛 열쇠";
            slotSelectMng.SelectSlot(this.gameObject);
            slotSelectMng.usableItem = "keySelected";
        }
        else
        {
            slotSelectMng.UnselectSlot(this.gameObject);
        }
    }
}
