﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorToB2 : Object
{
    UIManager uiManager;
    SlotSelectionMng slotSelectMng;
    [SerializeField] CardKey cardKey;
    [SerializeField] private GameObject withoutKeyUI;
    [SerializeField] private GameObject withKeyUI;
    [SerializeField] private Text withoutKeyText;
    [SerializeField] private Text withKeyText;
    [SerializeField] private Text inputTextUI;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public override void ObjectFunction()
    {
        cardKey = FindObjectOfType<CardKey>();
        if(cardKey && slotSelectMng.usableItem == "cardKeySelected")
        {
            withKeyUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(withKeyText.text, inputTextUI));
            slotSelectMng.SelectionClear();
        }
        else
        {
            withoutKeyUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(withoutKeyText.text, inputTextUI));
        }
    }
}
