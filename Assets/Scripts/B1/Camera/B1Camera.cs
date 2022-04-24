using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1Camera : CameraScript
{
    FloorTxt Ft;
    IntroScpt IntroScpt;
    public GameObject introCanvas;
    SoundManager sound;

    new void Start()
    {
        sound = SoundManager.inst;
        sound.B12BGMPlay();
        base.Start();
        Ft = FindObjectOfType<FloorTxt>();
        //player.currRoom = "B1_Hallway";
        saveData.currFloor = "B1";
        //saveData.currRoomPos = "복도";
        data.Save();
        Ft.PosUI();
        if(!saveData.texton)
        {
            introCanvas.SetActive(true);
            //인트로 시작을 어케해주냐는 말이야,,
        }
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
