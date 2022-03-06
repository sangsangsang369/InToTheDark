using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statue_nonsp : Object
{
    public GameObject statueUI;
    public Text statueText;
    public Text inputTextUI;
    B2_UIManager uiManager;
    bool playB2StatueOnce = false;

    DataManager data;
    SaveDataClass saveData;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        playB2StatueOnce = saveData.playB2StatueOnce;
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    public override void ObjectFunction()
    {
        if (!playB2StatueOnce)
        {
            statueUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(statueText.text, inputTextUI));
            playB2StatueOnce = true;
            saveData.playB2StatueOnce = true;
            data.Save();
        }
        else
        {
            Debug.Log("이미 읽어본 조각상입니다.");
        }
    }
}
