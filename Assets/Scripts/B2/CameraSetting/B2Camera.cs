using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class B2Camera : CameraScript
{
    SoundManager SM;
    FloorTxt Ft;
    DoorToB3 ToB3;
    //bool OutGallery = true; // 지하 2층 갤러리 나가면

    new void Start()
    {
        Ft = FindObjectOfType<FloorTxt>();
        SM = SoundManager.inst;
        ToB3 = FindObjectOfType<DoorToB3>();
        SM.PlayBGM(SM.B12BGM);
        SM.monsterGrowlingSource.Stop();
        SM.monsterWalkingSource.Stop();
        SM.playerHeartBeatSource.Stop();
        base.Start();
        if (saveData.isB3DoorOpened)
        {
            ToB3.CheckDoorOpen();
            ToB3.ReB2 = true;
            saveData.ReB2 = true;
            data.Save();
        }
        else
        {
            if (saveData.s1On)
            {
                ToB3.s1On = true;
                ToB3.s1.SetActive(true);
            }
            if (saveData.s2On)
            {
                ToB3.s2On = true;
                ToB3.s2.SetActive(true);
            }
        }
        
        //player.currRoom = "B2_Hallway";
        saveData.currFloor = "B2";
        //saveData.currRoomPos = "복도";
        data.Save();
        Ft.PosUI();
    }

    void Update()
    {
        CameraSetting();
    }

    public override void CameraSetting()
    {
        if (saveData.currRoomPos == "복도")
        {
            CameraLimit(-28.8f, 28.8f);
        }
        else if (saveData.currRoomPos == "시체의 방")
        {
            CameraLimit(-38.4f, -28.6f);
        }
        else if (saveData.currRoomPos == "전시실")
        {
            CameraLimit(-4.065f, 0.55f);
        }
    }
}

