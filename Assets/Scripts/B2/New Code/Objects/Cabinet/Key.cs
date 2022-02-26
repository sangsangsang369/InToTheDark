using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : Object
{
    public B2_UIManager uiManager;
    public InventoryMng inventoryMng;
    public Cabinet2 cab2;
    SlotSelectionMng slotSelectMng;
    int useOnce = 0;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        cab2 = FindObjectOfType<Cabinet2>();
    }

    // Update is called once per frame
    public void UseCardkey()
    {
        if (useOnce == 0)
        {
            if (slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.SelectSlot(this.gameObject);
                cab2.key1Picked = true;
                useOnce++;
                if (useOnce != 0)
                {
                    inventoryMng.RemoveFromInventory(slotSelectMng.selectedItem);
                    slotSelectMng.SelectionClear();
                }
            }
            else
            {
                slotSelectMng.UnselectSlot(this.gameObject);
            }
        }
    }
}
