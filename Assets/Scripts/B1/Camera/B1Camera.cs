using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1Camera : CameraScript
{
    FloorTxt Ft;
    SoundManager sound;

    new void Start()
    {
        sound = SoundManager.inst;
        sound.PlayBGM(sound.B12BGM);
        base.Start();
        Ft = FindObjectOfType<FloorTxt>();
        saveData.currFloor = "B1";
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
        if(saveData.currRoomPos == "복도")
        {
            CameraLimit(-28.8f, 28.8f);
        }
        else if(saveData.currRoomPos == "낡은 서재")
        {
            CameraLimit(-6.3f, 6.3f);
        }
    }
}
