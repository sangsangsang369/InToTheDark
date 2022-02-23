using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : Object
{
    public B2_UIManager uiManager;
    public InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;
    int useOnce = 0;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        
    }

    // Update is called once per frame
    public void UseClock()
    {
        if (useOnce == 0)
        {
            if (slotSelectMng.selectedItem != this.gameObject)
            {
                slotSelectMng.SelectSlot(this.gameObject);
                GameObject clockUI = GameObject.Find("ClockPanel");
                clockUI.SetActive(true);
                useOnce++;
                if(useOnce != 0)
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
