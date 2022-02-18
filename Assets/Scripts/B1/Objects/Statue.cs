using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statue : Object
{
    public GameObject statueUI;
    public Text statueText;
    public Text inputTextUI;
    UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public override void ObjectFunction()
    {
        statueUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(statueText.text, inputTextUI));
    }
}
