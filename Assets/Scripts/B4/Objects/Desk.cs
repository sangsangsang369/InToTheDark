using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desk : Object
{
    UIManager uiManager;
    InventoryMng inventoryMng;
    public bool isDaggerPicked = false;
    [SerializeField] private GameObject deskInChapelUI;
    [SerializeField] private GameObject daggerUI;
    [SerializeField] private Text daggerText;
    [SerializeField] private Text inputTextUI;
    [SerializeField] private GameObject dagger;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
    }

    public override void ObjectFunction()
    {
        if(!isDaggerPicked)
        {
            daggerUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(daggerText.text, inputTextUI));
            inventoryMng.PickUp(dagger);
            isDaggerPicked = true;
        }
        else
        {
            deskInChapelUI.SetActive(true);
        }
    }
}
