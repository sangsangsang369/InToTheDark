using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arm : Object
{
    B2_UIManager UIManager;
    public GameObject armUI;
    public List<Text> armTexts;
    public Text inputTextUI;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        UIManager = FindObjectOfType<B2_UIManager>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            armUI.SetActive(true);
            StartCoroutine(UIManager.LoadTexts(armTexts, inputTextUI, 2));
        }
    } 
}
