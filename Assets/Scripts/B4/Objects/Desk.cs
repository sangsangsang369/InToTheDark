using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desk : Object
{
    DataManager data;
    SaveDataClass saveData;
    SoundManager sound;

    UI uiManager;
    InventoryMng inventoryMng;
    public bool isDaggerPicked;
    [SerializeField] private GameObject deskInChapelUI;
    [SerializeField] private GameObject daggerUI;
    [SerializeField] private Text daggerText;
    [SerializeField] private Text inputTextUI;
    [SerializeField] private GameObject dagger;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        isDaggerPicked = saveData.isDaggerPicked;

        uiManager = FindObjectOfType<UI>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        sound = SoundManager.inst;
    }

    public override void ObjectFunction()
    {
        if(!isDaggerPicked)
        {
            sound.getItemEffectPlay();
            daggerUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(daggerText.text, inputTextUI));
            inventoryMng.PickUp(dagger, 0.1f, ItemClass.ItemPrefabOrder.Dagger);
            isDaggerPicked = true;
            saveData.isDaggerPicked = true;
            data.Save();
        }
        else
        {
            deskInChapelUI.SetActive(true);
        }
    }
}
