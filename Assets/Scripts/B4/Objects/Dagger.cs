using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dagger : MonoBehaviour
{
    [SerializeField] private GameObject daggerUI;
    [SerializeField] private Text daggerText;
    [SerializeField] private Text inputTextUI;
    [SerializeField] private GameObject prefabUI;
    UI uiManager;
    InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;

    DataManager data;
    SaveDataClass saveData;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        if(this.transform.parent.gameObject.layer != 10 && saveData.isDaggerPicked)
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
        uiManager = FindObjectOfType<UI>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void DaggerItem()
    {
        if(prefabUI.transform.parent == this.transform)
        {
            prefabUI.transform.SetParent(this.transform.parent.parent.parent.parent, false);
        }
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "단검";
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            daggerUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(daggerText.text, inputTextUI));
        }  
    }
}
