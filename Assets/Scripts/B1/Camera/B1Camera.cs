using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1Camera : CameraScript
{
    FloorTxt Ft;
    new void Start()
    {
        base.Start();
        Ft = FindObjectOfType<FloorTxt>();
        player.currRoom = "B1_Hallway";
        saveData.currFloor = "B1";
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
        if(player.currRoom == "B1_Hallway")
        {
            CameraLimit(-28.8f, 28.8f);
        }
        else if(player.currRoom == "B1_Library")
        {
            CameraLimit(-6.3f, 6.3f);
        }
    }
}
