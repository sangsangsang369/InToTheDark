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

    DataManager data;
    SaveDataClass saveData;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        if(this.transform.parent.gameObject.layer != 10 && saveData.isLetterPicked)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            if(this.GetComponent<SpriteRenderer>())
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        uiManager = FindObjectOfType<UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public override void ObjectFunction()
    {
        letterUI.SetActive(true);
        GameObject letter = this.gameObject;
        inventoryMng.PickUp(letter, 0.1f, ItemClass.ItemPrefabOrder.Letter);
        saveData.isLetterPicked = true;
        data.Save();
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
