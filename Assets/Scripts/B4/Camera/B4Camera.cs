using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B4Camera : CameraScript
{
    FloorTxt Ft;
    UI uiManager;
    SoundManager inst;
    public bool isB4ReEntered;
    public GameObject startUI;
    public Text startText;

   new void Start()
    {
        base.Start();
        Ft = FindObjectOfType<FloorTxt>();
        uiManager = FindObjectOfType<UI>();
        inst = SoundManager.inst;
        inst.PlayBGM(inst.B34BGM);
        saveData.currFloor = "B4";
        isB4ReEntered = saveData.isB4ReEntered;
        data.Save();
        Ft.PosUI();

        //이형체 복도에 존재할 때만 스크립트 뜨게
        if(isB4ReEntered == false) 
        {
            startUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(startText.text, uiManager.inputTextUI));
            
            isB4ReEntered = true;
            saveData.isB4ReEntered = true;
            data.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CameraSetting();
    }

    public override void CameraSetting()
    {
        if(saveData.currRoomPos == "이형체의 복도")
        {
            CameraLimit(-28.8f, 28.8f);
        }
        else if(saveData.currRoomPos == "예배당")
        {
            CameraLimit(-4.6f, 4.6f);
        }
        else if(saveData.currRoomPos == "수상한 실험실")
        {
            CameraLimit(-8.22f, 8.22f);
        }
    }
}
