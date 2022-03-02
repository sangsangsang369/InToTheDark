using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hands : Object
{
    DataManager data;
    SaveDataClass saveData;

    private UI uiManager;
    private Desk desk;
    public bool isJewelGained;
    [SerializeField] private GameObject WithoutDaggerUI;
    [SerializeField] private GameObject WithDaggerUI;
    [SerializeField] private Text handsWithoutDaggerText;
    [SerializeField] private Text handsWithDaggerText;
    [SerializeField] private Text inputTextUI;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        isJewelGained = saveData.isJewelGained;

        uiManager = FindObjectOfType<UI>();
        desk = FindObjectOfType<Desk>();
    }

    public override void ObjectFunction()
    {
        if(!desk.isDaggerPicked)
        {
            WithoutDaggerUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(handsWithoutDaggerText.text, inputTextUI));
        }
        else if(desk.isDaggerPicked && !isJewelGained)
        {
            WithDaggerUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(handsWithDaggerText.text, inputTextUI));
        }
        else
        {
            WithoutDaggerUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(handsWithoutDaggerText.text, inputTextUI));
        }
    }
}
