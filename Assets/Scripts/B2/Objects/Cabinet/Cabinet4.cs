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

    void Start()
    {
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
        SM = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        cabinet4UI.SetActive(true);
        SM.cabinetOpenShortEffectPlay();
        SM.cabinetOpenLongEffectPlay();
        StartCoroutine(uiManager.LoadTextOneByOne(cabinet4Text.text, inputTextUI));
    }
}

