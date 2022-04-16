using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cabinet4 : Object
{
    public B2_UIManager uiManager;
    public GameObject cabinet4UI;
    public Text cabinet4Text;
    public Text inputTextUI;
    Player player;
    SoundManager SM;
    public AudioClip cabinetOpenShortEffect;

    void Start()
    {
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
        SM = SoundManager.inst;
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        cabinet4UI.SetActive(true);
        SM.EffectPlay(cabinetOpenShortEffect);
        //SM.cabinetOpenLongEffectPlay();
        StartCoroutine(uiManager.LoadTextOneByOne(cabinet4Text.text, inputTextUI));
    }
}

