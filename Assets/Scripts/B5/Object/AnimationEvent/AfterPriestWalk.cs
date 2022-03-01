using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterPriestWalk : MonoBehaviour
{
    //사제 걸어나오는 애니메이션 이후 실행되는 스크립트
    //사제 대사 텍스트 나오게

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
