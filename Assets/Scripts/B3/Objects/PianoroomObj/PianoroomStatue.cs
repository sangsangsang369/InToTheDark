using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoroomStatue : Object
{
    public GameObject pianoroomStatueUI;
    B3UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<B3UIManager>();
    }

    public override void ObjectFunction()
    {
        pianoroomStatueUI.SetActive(true);
        StartCoroutine(uiManager.LoadPianoStatueTexts());
    }
    
}
