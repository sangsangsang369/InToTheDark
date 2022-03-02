using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dagger : MonoBehaviour
{
    [SerializeField] private GameObject daggerUI;
    [SerializeField] private Text daggerText;
    [SerializeField] private Text inputTextUI;
    UI uiManager;
    InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        uiManager = FindObjectOfType<UI>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void DaggerItem()
    {
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            daggerUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(daggerText.text, inputTextUI));
        }  
    }
}
