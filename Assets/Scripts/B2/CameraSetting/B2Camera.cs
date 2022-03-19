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
        SM = FindObjectOfType<SoundManager>();
        ToB3 = FindObjectOfType<DoorToB3>();
        SM.B12BGMPlay();
        base.Start();
        if (saveData.isB3DoorOpened)
        {
            ToB3.CheckDoorOpen();
            ToB3.ReB2 = true;
            saveData.ReB2 = true;
            data.Save();
        }
        player.currRoom = "B2_Hallway";
        saveData.currFloor = "B2";
        saveData.currRoomPos = "복도";
        data.Save();
        Ft.PosUI();
    }

    void Update()
    {
        CameraSetting();
    }

    public override void CameraSetting()
    {
        if (player.currRoom == "B2_Hallway")
        {
            CameraLimit(-28.8f, 28.8f);
        }
        else if (player.currRoom == "B2_Cabinet")
        {
            CameraLimit(-38.4f, -28.6f);
        }
        else if (player.currRoom == "B2_Gallery")
        {
            CameraLimit(-4.065f, 0.55f);
        }
    }
}

