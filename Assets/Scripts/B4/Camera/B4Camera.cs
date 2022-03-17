using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4Camera : CameraScript
{
    new void Start()
    {
        base.Start();
        player.currRoom = "B4_Hallway";
        saveData.currFloor = "B4";
        saveData.currRoomPos = "복도";
        data.Save();
    }

    // Update is called once per frame
    void Update()
    {
        CameraSetting();
    }

    public override void CameraSetting()
    {
        if(player.currRoom == "B4_Hallway")
        {
            CameraLimit(-28.8f, 28.8f);
        }
        else if(player.currRoom == "B4_Chapel")
        {
            CameraLimit(-4.6f, 4.6f);
        }
        else if(player.currRoom == "B4_Lab")
        {
            CameraLimit(-8.22f, 8.22f);
        }
    }
}
