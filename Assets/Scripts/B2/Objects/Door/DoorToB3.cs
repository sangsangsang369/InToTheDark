using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorToB3 : Object
{
    public B2_UIManager uiManager;
    public InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;
    Sword1 sword1;
    Sword2 sword2;
    public bool isB3DoorOpened = false;

    public GameObject s1, s2, cover, blood, swordDown, DoorUI;
    public bool s1On = false;
    public bool s2On = false;
    public Text doorText, inputTextUI;

    DataManager data;
    SaveDataClass saveData;
    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        isB3DoorOpened = saveData.isB3DoorOpened;

        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        sword1 = FindObjectOfType<Sword1>();
        sword2 = FindObjectOfType<Sword2>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (!isB3DoorOpened)
        {
            if (slotSelectMng.usableItem == "sword1Selected")
            {
                s1.SetActive(true);
                s1On = true;
                inventoryMng.RemoveFromInventory(slotSelectMng.selectedItem, ItemClass.ItemPrefabOrder.Sword1);
                slotSelectMng.SelectionClear();
            }
            if (slotSelectMng.usableItem == "sword2Selected")
            {
                s2.SetActive(true);
                s2On = true;
                inventoryMng.RemoveFromInventory(slotSelectMng.selectedItem, ItemClass.ItemPrefabOrder.Sword2);
                slotSelectMng.SelectionClear();
            }
            if (s1On && s2On)
            {
                DoorUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(doorText.text, inputTextUI));
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    GetComponent<Animator>().SetTrigger("GoDown");
                    Invoke("Wait5Sec", 3f);
                }
            }
        }
        
    }

    public void Wait5Sec()
    {
        Debug.Log("5");
        s1.SetActive(false);
        s2.SetActive(false);
        cover.SetActive(true);
        cover.GetComponent<Animator>().SetTrigger("MakeDark");
        blood.SetActive(true);
        isB3DoorOpened = true;
        saveData.isB3DoorOpened = true;
        data.Save();
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        Invoke("Keeping", 3f);
    }

    public void Keeping()
    {
        cover.SetActive(false);
        swordDown.SetActive(true);
        SceneManager.LoadScene("B3");
    }
}
