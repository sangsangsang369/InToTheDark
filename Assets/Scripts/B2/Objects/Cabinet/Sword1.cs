using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword1 : Object
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
    public  void UseSword1()
    {
        if (slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "피 묻은 칼";
            slotSelectMng.SelectSlot(this.gameObject);
            slotSelectMng.usableItem = "sword1Selected";
        }
        else 
        {
            slotSelectMng.UnselectSlot(this.gameObject);
        }
    }

}
