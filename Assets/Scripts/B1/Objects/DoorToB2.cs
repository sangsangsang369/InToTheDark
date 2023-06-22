using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorToB2 : Object
{
    DataManager data;
    SaveDataClass saveData;
    UIManager uiManager;
    SlotSelectionMng slotSelectMng;
    [SerializeField] CardKey cardKey;
    [SerializeField] private GameObject withoutKeyUI;
    [SerializeField] private GameObject withKeyUI;
    [SerializeField] private Text withoutKeyText;
    [SerializeField] private Text withKeyText;
    [SerializeField] private Text inputTextUI;
    SaveAlarm saveAlarm;
    SoundManager sound;


    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        uiManager = FindObjectOfType<UIManager>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        saveAlarm = FindObjectOfType<SaveAlarm>();
        sound = SoundManager.inst;
    }

    public override void ObjectFunction()
    {
        cardKey = FindObjectOfType<CardKey>();
        if(saveData.isB2DoorOpened == false){
            if(cardKey && slotSelectMng.usableItem == "cardKeySelected")
            {
                saveData.isB2DoorOpened = true;
                data.Save();
                sound.EffectPlay(sound.doorUnlockEffect);
                withKeyUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(withKeyText.text, inputTextUI));
                slotSelectMng.SelectionClear();
                saveAlarm.SaveAlarmPopUp();
            }
            else
            {
                withoutKeyUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(withoutKeyText.text, inputTextUI));
            }
        }
        else {
            sound.EffectPlay(sound.doorUnlockEffect);
            withKeyUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(withKeyText.text, inputTextUI));
            slotSelectMng.SelectionClear();
            saveAlarm.SaveAlarmPopUp();
        }
        
    }
}
