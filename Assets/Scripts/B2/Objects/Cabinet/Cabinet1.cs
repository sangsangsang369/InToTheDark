using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabinet1 : Object
{
    public B2_UIManager uiManager;
    public GameObject cabinet1UI;
    public Text cabinet1Text;
    public Text inputTextUI;
    public AudioClip cabinetOpenShortEffect;
    Player player;
    SoundManager SM;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
        SM = SoundManager.inst;
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        SM.EffectPlay(cabinetOpenShortEffect);
        //SM.cabinetOpenLongEffectPlay();
        cabinet1UI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(cabinet1Text.text, inputTextUI));
    }
}
