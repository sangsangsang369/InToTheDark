using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryCloseBtn : MonoBehaviour
{
    public bool isClicked;
    UIManager uiManager;
    public GameObject cardkeyUI;
    public GameObject cardKey;
    InventoryMng inventoryMng;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        uiManager = FindObjectOfType<UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
    }

    public void Clicked()
    {
        if(!isClicked)
        {
            cardkeyUI.SetActive(true);
            isClicked = true;
            uiManager.StartCoroutine(uiManager.LoadCardkeyTexts());
            inventoryMng.AddToInventory(cardKey, 0.1f);
        }
    }
}
