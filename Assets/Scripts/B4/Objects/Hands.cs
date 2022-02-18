using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hands : Object
{
    private UIManager uiManager;
    private Desk desk;
    public bool isJewelGained = false;
    [SerializeField] private GameObject WithoutDaggerUI;
    [SerializeField] private GameObject WithDaggerUI;
    [SerializeField] private Text handsWithoutDaggerText;
    [SerializeField] private Text handsWithDaggerText;
    [SerializeField] private Text inputTextUI;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
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
