using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leg : Object
{
    B2_UIManager UIManager;
    public GameObject legUI;
    public List<Text> legTexts;
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
           StartCoroutine(UIManager.LoadTexts(legTexts, inputTextUI, 2));
        }
    } 
}
