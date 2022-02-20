using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterPriestWalk : MonoBehaviour
{
    public GameObject priestUI;
    public List<Text> priestTexts;
    public Text inputTextUI;
    B5_UIManager uiManager;
    public int scptOn = 0;


     void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
    }

    public void PriestScptOn()
    {
        scptOn = 1; 
        priestUI.SetActive(true);
        uiManager.StartCoroutine(uiManager.LoadTexts(priestTexts, inputTextUI, 10));
    }
}
