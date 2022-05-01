using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cabinet3 : Object
{
    public B2_UIManager uiManager;
    public InventoryMng inventoryMng;
    public GameObject cabinet3UI, clockImg;
    public GameObject clockPanel;
    public List<Text> cabinet3Texts;
    public Text cabinet3openedText;
    public Text inputTextUI;
    public bool alreadyOpen;
    Player player;

    DataManager data;
    SaveDataClass saveData;
    SoundManager SM;
    public AudioClip cabinetOpenShortEffect, cabinetOpenLongEffect;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        alreadyOpen = saveData.alreadyOpen;

        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        SM = SoundManager.inst;
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!alreadyOpen)
            {
                SM.EffectPlay(cabinetOpenLongEffect);
                //SM.cabinetOpenLongEffectPlay();
                cabinet3UI.SetActive(true);
                StartCoroutine(uiManager.LoadTexts(cabinet3Texts, inputTextUI, 3));
                GameObject clock = clockImg;
                inventoryMng.AddToInventory(clock, 1f, ItemClass.ItemPrefabOrder.PocketWatch);
                alreadyOpen = true;
                saveData.alreadyOpen = true;
                data.Save();
            }
            else
            {
                SM.EffectPlay(cabinetOpenShortEffect);
                cabinet3UI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(cabinet3openedText.text, inputTextUI));
            }
        }
    }
}
