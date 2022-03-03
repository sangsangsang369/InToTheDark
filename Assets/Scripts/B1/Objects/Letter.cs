using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : Object
{
    public GameObject letterUI;
    public Sprite letterItemImg;
    UIManager uiManager;
    InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public override void ObjectFunction()
    {
        letterUI.SetActive(true);
        GameObject letter = this.gameObject;
        inventoryMng.PickUp(letter, 0.1f);
    }

    public void LetterItem()
    {
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            letterUI.SetActive(true);
        }
    }
}
