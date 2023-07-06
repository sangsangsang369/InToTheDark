using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MufflerBtn : MonoBehaviour
{
    B5_UIManager uiManager;
    public MonsterBro monsterBro;
    public GameObject textUI;
    public List<Text> muffTexts;
    public Text inputTextUI;

    SoundManager inst;


    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        //monsterBro  = FindObjectOfType<MonsterBro>();
        inst = SoundManager.inst;
    }

    public void Clicked(){
        textUI.SetActive(true);
        StartCoroutine(uiManager.LoadTexts(muffTexts, inputTextUI,2));
        PlayOnBGM();
        monsterBro.monsterBroTrigger_Muf = true;
    }

    public void PlayOnBGM(){
        inst.PlayBGM(inst.endingBGM2);
    }
}
