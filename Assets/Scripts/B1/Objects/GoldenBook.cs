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
    SoundManager sound;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        sound = SoundManager.inst;
    }

    public override void ObjectFunction()
    {
        sound.EffectPlay(sound.bookSelectEffect);
        goldenBookUI.SetActive(true);
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(uiManager.LoadGoldenBookText(goldenBookTexts, inputTextUI, gbNameText, gbIllust, gbImage, gbLetterImg));
        }
    }
}
