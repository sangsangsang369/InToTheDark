using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoveStatue : MonoBehaviour
{
    B2_UIManager uiManager;
    public StatuePuzzle SP;
    public StatuePuzzle2 SP2;
    public StatuePuzzle3 SP3;
    public StatuePuzzle4 SP4;
    public InventoryMng inventoryMng;
    public GameObject sword2UI, sword2Img;
    public Text sword2Text;
    public Text inputTextUI;
    bool playPuzzleOnce = false;

    DataManager data;
    SaveDataClass saveData;
    SoundManager SM;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        playPuzzleOnce = saveData.playPuzzleOnce;
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        SM = SoundManager.inst;
    }


    void Update()
    {
        if((SP.statue1Fliped) && (SP2.statue2Fliped) && (!SP3.statue3Fliped) && (SP4.statue4Fliped))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && (!playPuzzleOnce))
            {
                CheckAnswer();
            }
        }
    }

    public void CheckAnswer()
    {
        SM.ItemEffectPlaying(SM.knifefalling);
        sword2UI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(sword2Text.text, inputTextUI));
        GameObject sword2 = sword2Img;
        inventoryMng.AddToInventory(sword2, 1f, ItemClass.ItemPrefabOrder.Sword2);
        playPuzzleOnce = true;
        saveData.playPuzzleOnce = true;
        data.Save();
    }
}
