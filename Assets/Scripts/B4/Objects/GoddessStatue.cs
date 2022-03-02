using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoddessStatue : Object
{
    private UI uiManager;
    [SerializeField] private GameObject goddessStatueUI;
    [SerializeField] private Text goddessStatueText;
    [SerializeField] private Text inputTextUI;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UI>();
    }

    public override void ObjectFunction()
    {
        goddessStatueUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(goddessStatueText.text, inputTextUI));
    }
}
