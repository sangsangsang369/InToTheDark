using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class DoorToLab : Object
{
    CardKey cardKey;
    SlotSelectionMng slotSelectMng;
    UI uiManager;
    SoundManager sound;
    DataManager data;
    SaveDataClass saveData;
    [SerializeField] private GameObject withoutKeyUI;
    [SerializeField] private GameObject withKeyUI;
    [SerializeField] private Text withoutKeyText;
    [SerializeField] private Text withKeyText;
    [SerializeField] private Text inputTextUI;
    bool isLabOpened;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        uiManager = FindObjectOfType<UI>();
        sound = SoundManager.inst;
        isLabOpened = saveData.isLabDoorOpened;
    }

    public override void ObjectFunction()
    {
        cardKey = FindObjectOfType<CardKey>();
        if(isLabOpened){
            sound.EffectPlay(sound.doorUnlockEffect);
            withKeyUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(withKeyText.text, inputTextUI));
        }
        else{
            if(cardKey && slotSelectMng.usableItem == "cardKeySelected")
            {
                sound.EffectPlay(sound.doorUnlockEffect);
                withKeyUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(withKeyText.text, inputTextUI));
                slotSelectMng.SelectionClear();
                isLabOpened = true;
                data.Save();
            }
            else
            {
                withoutKeyUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(withoutKeyText.text, inputTextUI));
            }
        }
        
    }
}
