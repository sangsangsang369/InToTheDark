using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3CameraLimit : CameraScript
{
    SoundManager inst;
    FloorTxt Ft;

    new void Start()
    {
        base.Start();
        inst = SoundManager.inst;
        inst.PlayBGM(inst.B34BGM);
        inst.effectSource.clip = null;
        Ft = FindObjectOfType<FloorTxt>();
        saveData.currFloor = "B3";
        data.Save();
        Ft.PosUI();
    }

    // Update is called once per frame
    void Update()
    {
        CameraSetting();
    }

    public override void CameraSetting()
    {
        if (saveData.currRoomPos == "피투성이 복도")
        {
            CameraLimit(-28.8f, 28.8f);
        }
        if (saveData.currRoomPos == "거대한 정원")
        {
            CameraLimit(-12.7f, 12.7f);
        }
        if (saveData.currRoomPos == "합주실")
        {
            CameraLimit(-8.5f, 8.5f);
        }
    }
}

