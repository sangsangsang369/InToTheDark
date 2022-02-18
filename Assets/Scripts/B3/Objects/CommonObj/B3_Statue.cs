using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B3_Statue : Object
{
   public GameObject statueUI;
    public Text statueText;
    public Text inputTextUI;
    B3UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<B3UIManager>();
    }

    public override void ObjectFunction()
    {
        statueUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(statueText.text, inputTextUI));
        }
}

