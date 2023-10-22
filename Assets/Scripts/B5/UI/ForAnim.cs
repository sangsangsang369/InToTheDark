using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForAnim : MonoBehaviour
{
    B5_UIManager uiManager;
    public GameObject textsUI;
    public List<Text> newsTexts;
    public Text inputText2UI;
    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
    }
    public void SetOnTrigger(){
        this.GetComponent<Animator>().SetTrigger("ZoomOut");
    }

    public void OnScpt(){
        textsUI.SetActive(true);
        StartCoroutine(uiManager.LoadTexts(newsTexts, inputText2UI,3));
    }
}
