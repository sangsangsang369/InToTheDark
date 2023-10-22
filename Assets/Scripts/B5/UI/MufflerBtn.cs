using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MufflerBtn : MonoBehaviour
{
    B5_UIManager uiManager;
    MonsterBro monsterBro;
    public GameObject textUI;
    public GameObject textsUI;
    public List<Text> muffTexts;
    public List<Text> newsTexts;
    public Text inputTextUI, inputText2UI;

    public GameObject fadeOut;
    SoundManager inst;
    public AudioClip endingBGM2;
    public GameObject newsScene1;
    public List<GameObject> covers;
    public GameObject cover;


    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        monsterBro  = FindObjectOfType<MonsterBro>();
        inst = SoundManager.inst;
    }

    public void Clicked(){
        textUI.SetActive(true);
        StartCoroutine(uiManager.LoadTexts(muffTexts, inputTextUI,2));
        fadeOut.SetActive(true);
        PlayOnBGM();
    }

    public void PlayOnBGM(){
        inst.PlayBGM(endingBGM2);
    }
}
