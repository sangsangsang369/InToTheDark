using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabinet2 : Object
{
    public UI uiManager;
    public InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;
    public GameObject cabinet2UI, sword1UI, sword1Img;
    public Text cabinet2Text, sword1Text, cabinet2openedText;
    public Text inputTextUI;
    Player player;
    Key key; 
    SoundManager SM;
    DataManager data;
    SaveDataClass saveData;
    public bool keyUsed;
    SaveAlarm saveAlarm;
    public AudioClip cabinetOpenShortEffect;
    public AudioClip cabinetOpenLongEffect;
    //public AudioClip lockerOpenEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        SM = SoundManager.inst;
        data = DataManager.singleTon;
        saveData = data.saveData;
        keyUsed = saveData.keyUsed;
        saveAlarm = FindObjectOfType<SaveAlarm>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                key = FindObjectOfType<Key>();
                if (!keyUsed && key && slotSelectMng.usableItem == "keySelected")
                {
                    SM.EffectPlay(cabinetOpenLongEffect);
                    saveAlarm.SaveAlarmPopUp();
                    sword1UI.SetActive(true);
                    SM.ItemEffectPlaying(SM.knifefalling);
                    StartCoroutine(uiManager.LoadTextOneByOne(sword1Text.text, inputTextUI));
                    inventoryMng.RemoveFromInventory(slotSelectMng.selectedItem, ItemClass.ItemPrefabOrder.CabinetKey);
                    slotSelectMng.SelectionClear();
                    GameObject sword1 = sword1Img;
                    inventoryMng.AddToInventory(sword1, 1f, ItemClass.ItemPrefabOrder.Sword1);
                    keyUsed = true;
                    saveData.keyUsed = true;
                    data.Save();
                }
                else if (!keyUsed)
                {
                    SM.EffectPlay(cabinetOpenShortEffect);
                    cabinet2UI.SetActive(true);
                    StartCoroutine(uiManager.LoadTextOneByOne(cabinet2Text.text, inputTextUI));
                }
                else if (keyUsed)
                {
                    cabinet2UI.SetActive(true);
                    StartCoroutine(uiManager.LoadTextOneByOne(cabinet2openedText.text, inputTextUI));
                }
            } 
    }
}
