using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : Object
{
    public B2_UIManager uiManager;
    public InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
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
