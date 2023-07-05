using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sack2 : Object
{
    public B2_UIManager UIManager;
    public GameObject sack2UI;
    public List<Text> sack2Texts;
    public Text inputTextUI;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        UIManager = FindObjectOfType<B2_UIManager>();
    }

    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            sack2UI.SetActive(true);
            StartCoroutine(UIManager.LoadTexts(sack2Texts, inputTextUI, 5));
        }
    } 
}

