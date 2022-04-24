using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : Object
{
    public GameObject consoleUI;
    public Text consoleText;
    public Text inputTextUI;
    UI uiManager;
    SoundManager inst;

    void Start()
    {
        uiManager = FindObjectOfType<UI>();
        inst = SoundManager.inst;
    }

    public override void ObjectFunction()
    {
        inst.EffectPlay(inst.consoleTouchEffect);
        consoleUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(consoleText.text, inputTextUI));
    }
}
