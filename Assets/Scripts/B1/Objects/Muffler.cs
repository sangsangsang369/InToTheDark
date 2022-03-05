using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Muffler : Object
{
    public GameObject mufflerUI;
    public Text mufflerText;
    public Text inputTextUI;
    UIManager uiManager;
    InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;

    DataManager data;
    SaveDataClass saveData;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        if(this.transform.parent.gameObject.layer != 10 && saveData.isMufflerPicked)
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
        mufflerUI.SetActive(true);
        uiManager.StartCoroutine(uiManager.LoadTextOneByOne(mufflerText.text, inputTextUI));
        GameObject muffler = this.gameObject;
        inventoryMng.PickUp(muffler, 0.1f, ItemClass.ItemPrefabOrder.Muffler);
        saveData.isMufflerPicked = true;
        data.Save();
    }

    public void MufflerItem()
    {
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            mufflerUI.SetActive(true);
            uiManager.StartCoroutine(uiManager.LoadTextOneByOne(mufflerText.text, inputTextUI));
        }
    }
}
