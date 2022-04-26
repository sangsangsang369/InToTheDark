using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrokenCapsule : Object
{
    public GameObject brokenCapsuleUI;
    public Text brokenCapsuleText;
    public Text inputTextUI;
    UI uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UI>();
    }

    public override void ObjectFunction()
    {
        brokenCapsuleUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(brokenCapsuleText.text, inputTextUI));
    }
}
