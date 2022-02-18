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

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
    }

    public override void ObjectFunction()
    {
        letterUI.SetActive(true);
        GameObject letter = this.gameObject;
        inventoryMng.PickUp(letter);
    }

    public void LetterItem()
    {
        letterUI.SetActive(true);
    }
}
