using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class B2Camera : CameraScript
{
    SoundManager SM;
    //bool OutGallery = true; // 지하 2층 갤러리 나가면

    new void Start()
    {
        SM = FindObjectOfType<SoundManager>();
        SM.B12BGMPlay();
        base.Start();
        player.currRoom = "B2_Hallway";
        saveData.currFloor = "B2";
        saveData.currRoomPos = "복도";
        data.Save();
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

