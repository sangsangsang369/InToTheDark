using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorToB3 : Object
{
    public B2_UIManager uiManager;
    public InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;
    Sword1 sword1;
    Sword2 sword2;
    public bool isB3DoorOpened = false;
    public bool ReB2;
    public bool endAllAnim = false;
    bool OnScript = false;

    public GameObject s1, s2, cover, blood, upblood, swordDown, DoorUI, fullSword;
    public bool s1On = false;
    public bool s2On = false;
    public bool doorCheck = false;
    public Text doorText, inputTextUI;

    DataManager data;
    SaveDataClass saveData;
    FloorTxt Ft;
    SoundManager SM;
    SaveAlarm saveAlarm;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        isB3DoorOpened = saveData.isB3DoorOpened;
        s1On = saveData.s1On;
        s2On = saveData.s2On;
        ReB2 = saveData.ReB2;

        SM = SoundManager.inst;
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        sword1 = FindObjectOfType<Sword1>();
        sword2 = FindObjectOfType<Sword2>();
        Ft = FindObjectOfType<FloorTxt>();
        saveAlarm = FindObjectOfType<SaveAlarm>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (endAllAnim)
        {
            saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B4leftDoor];
            saveData.currFloor = "B3";
            saveData.currRoomPos = "피투성이 복도";
            data.Save();
            Ft.PosUI();
            endAllAnim = false;
            LoadScene("B3");
        }
        if (!isB3DoorOpened & !doorCheck)
        {
            ReB2 = false;
            saveData.ReB2 = false;
            data.Save();
            if (slotSelectMng.usableItem == "sword1Selected")
            {
                SM.EffectPlay(SM.knifeEffect);
                s1.SetActive(true);
                s1On = true;
                saveData.s1On = true;
                data.Save();
                inventoryMng.RemoveFromInventory(slotSelectMng.selectedItem, ItemClass.ItemPrefabOrder.Sword1);
                slotSelectMng.SelectionClear();
            }
            if (slotSelectMng.usableItem == "sword2Selected")
            {
                SM.EffectPlay(SM.knifeEffect);
                s2.SetActive(true);
                s2On = true;
                saveData.s2On = true;
                data.Save();
                inventoryMng.RemoveFromInventory(slotSelectMng.selectedItem, ItemClass.ItemPrefabOrder.Sword2);
                slotSelectMng.SelectionClear();
            }
            if (s1On && s2On)
            {
                doorCheck = true;
                if (doorCheck)
                {
                    SM.EffectPlay(SM.swipeStatueEffect);
                    if (!OnScript)
                    {
                        DoorUI.SetActive(true);
                        StartCoroutine(uiManager.LoadTextOneByOne(doorText.text, inputTextUI));
                        OnScript = true;
                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            GetComponent<Animator>().SetTrigger("GoDown");
                            s1.SetActive(false);
                            s2.SetActive(false);
                            Invoke("WaitSec", 3f);
                        }
                    }
                }
            }
        }
        else if (ReB2)
        {
            saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B4leftDoor];
            saveData.currFloor = "B3";
            saveData.currRoomPos = "피투성이 복도";
            data.Save();
            Ft.PosUI();
            LoadScene("B3");
        }
    }

    public void CheckDoorOpen()
    {
        s1.SetActive(false);
        s2.SetActive(false);
        cover.SetActive(false);
        blood.SetActive(true);
        upblood.SetActive(true);
        fullSword.SetActive(true);
    }

    public void WaitSec()
    {
        cover.SetActive(true);
        StartCoroutine(MakeDark());
        isB3DoorOpened = true;
        saveData.isB3DoorOpened = true;
        data.Save();
        Invoke("GooSound", 3f);
        Invoke("Keeping", 4f);
    }

    public void Keeping()
    {
        upblood.SetActive(true);
        blood.SetActive(true);
        fullSword.SetActive(true);
        cover.SetActive(false);
        endAllAnim = true;
        saveAlarm.SaveAlarmPopUp();
    }
    private void GooSound()
    {
        SM.EffectPlay(SM.gooEffect);
    }

    IEnumerator MakeDark()
    {
        float fadeCount = 0; //투명도(알파값) 초기 설정
        while (fadeCount < 1.0f) //알파값 255가 될 때까지
        {
            fadeCount += 0.15f;
            yield return new WaitForSeconds(0.1f);
            cover.GetComponent<Image>().color = new Color(0, 0, 0, fadeCount);
        }
    }
}
