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
    bool playOnce = false;

    void Start()
    {
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    public override void ObjectFunction()
    {
        if (!playOnce)
        {
            statueUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(statueText.text, inputTextUI));
            playOnce = true;
        }
        else
        {
            Debug.Log("이미 실행된 돋보기입니다.");
        }
    }
}
