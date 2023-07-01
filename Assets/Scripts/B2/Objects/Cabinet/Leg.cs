using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leg : Object
{
    B2_UIManager UIManager;
    public GameObject legUI;
    public Text legText;
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
            legUI.SetActive(true);
            StartCoroutine(UIManager.LoadTextOneByOne(legText.text, inputTextUI));
        }
    } 
}
