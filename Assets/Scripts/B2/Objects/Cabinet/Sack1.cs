using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sack1 : Object
{
    public B2_UIManager UIManager;
    public GameObject sack1UI;
    public List<Text> sack1Texts;
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
            sack1UI.SetActive(true);
            StartCoroutine(UIManager.LoadTexts(sack1Texts, inputTextUI, 2));
        }
    } 
}
