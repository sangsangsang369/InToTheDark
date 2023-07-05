using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MufflerBtn : MonoBehaviour
{
    B5_UIManager uiManager;
    MonsterBro monsterBro;
    public GameObject textUI;
    public List<Text> muffTexts;
    public Text inputTextUI;


    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        monsterBro  = FindObjectOfType<MonsterBro>();
    }

    public void Clicked(){
        textUI.SetActive(true);
        StartCoroutine(uiManager.LoadTexts(muffTexts, inputTextUI,2));
    }
}
