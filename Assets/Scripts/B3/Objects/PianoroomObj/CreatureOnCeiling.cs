using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
public class CreatureOnCeiling : Object
{
   public GameObject creatureOnCeilingUI;
    public Text creatureOnCeilingText;
    public Text inputTextUI;
    B3UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<B3UIManager>();
    }

    public override void ObjectFunction()
    {
        creatureOnCeilingUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(creatureOnCeilingText.text, inputTextUI));
    }
}

