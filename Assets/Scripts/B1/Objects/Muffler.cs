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

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
    }

    public override void ObjectFunction()
    {
        mufflerUI.SetActive(true);
        uiManager.StartCoroutine(uiManager.LoadTextOneByOne(mufflerText.text, inputTextUI));
        GameObject muffler = this.gameObject;
        inventoryMng.PickUp(muffler);
    }

    public void MufflerItem()
    {
        mufflerUI.SetActive(true);
        uiManager.StartCoroutine(uiManager.LoadTextOneByOne(mufflerText.text, inputTextUI));
    }
}
