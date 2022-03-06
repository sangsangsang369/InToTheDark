using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B2_Poetry : Object
{
    public B2_UIManager uiManager;
    public GameObject poetryUI;
    public List<Text> poetryTexts;
    public Text inputTextUI;
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
        poetryUI.SetActive(true);
        StartCoroutine(uiManager.LoadTexts(poetryTexts, inputTextUI, 4));
    }
}
