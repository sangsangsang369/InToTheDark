using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3CameraLimit : CameraScript
{
    FloorTxt Ft;

    new void Start()
    {
        base.Start();
        Ft = FindObjectOfType<FloorTxt>();
        player.currRoom="B3_Hallway";
        saveData.currFloor = "B3";
        saveData.currRoomPos = "복도";
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
        if (player.currRoom=="B3_Hallway")
        {
            CameraLimit(-28.8f, 28.8f);
        }
        if (player.currRoom=="B3_Treeroom")
        {
            CameraLimit(-12.7f, 12.7f);
        }
        if (player.currRoom=="B3_Pianoroom")
        {
            CameraLimit(-8.5f, 8.5f);
        }
    }
}

