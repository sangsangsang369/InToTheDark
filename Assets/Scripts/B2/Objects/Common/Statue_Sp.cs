using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statue_Sp : Object
{
    public GameObject statueSpUI;
    public List<Text> statueSpTexts;
    public Text inputTextUI;
    B2_UIManager uiManager;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            statueSpUI.SetActive(true);
            StartCoroutine(uiManager.LoadTexts(statueSpTexts, inputTextUI, 3));
        }
    }
}
