using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryCloseBtn : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;

    public bool isDiaryClicked;
    UIManager uiManager;
    public GameObject cardkeyUI;
    public GameObject cardKey;
    InventoryMng inventoryMng;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        isDiaryClicked = saveData.isDiaryClicked;
        uiManager = FindObjectOfType<UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
    }

    public void Clicked()
    {
        if(!isDiaryClicked)
        {
            cardkeyUI.SetActive(true);
            isDiaryClicked = true;
            saveData.isDiaryClicked = true;
            uiManager.StartCoroutine(uiManager.LoadCardkeyTexts());
            inventoryMng.AddToInventory(cardKey, 0.1f, ItemClass.ItemPrefabOrder.CardKey);
            data.Save();
        }
    }
}
