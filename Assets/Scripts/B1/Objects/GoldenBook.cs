using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenBook : Object
{
    public GameObject goldenBookUI, gbIllust;
    public List<Text> goldenBookTexts;
    public Text inputTextUI, gbNameText;
    public Sprite gbImage, gbLetterImg;
    UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public override void ObjectFunction()
    {
        goldenBookUI.SetActive(true);
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(uiManager.LoadGoldenBookText(goldenBookTexts, inputTextUI, gbNameText, gbIllust, gbImage, gbLetterImg));
        }
    }
}
