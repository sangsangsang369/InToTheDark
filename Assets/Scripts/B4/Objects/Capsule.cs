using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capsule : Object
{
    public GameObject capsuleUI;
    public List<Text> capsuleTexts;
    public Text inputTextUI;
    UI uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UI>();
    }

    public override void ObjectFunction()
    {
        capsuleUI.SetActive(true);
        StartCoroutine(uiManager.LoadTexts(capsuleTexts, inputTextUI, 3));
    }
}
