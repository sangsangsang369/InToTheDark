using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dagger : MonoBehaviour
{
    [SerializeField] private GameObject daggerUI;
    [SerializeField] private Text daggerText;
    [SerializeField] private Text inputTextUI;
    UIManager uiManager;
    InventoryMng inventoryMng;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
    }

    public void DaggerItem()
    {
        daggerUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(daggerText.text, inputTextUI));
    }
}
