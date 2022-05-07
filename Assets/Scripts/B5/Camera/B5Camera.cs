using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B5Camera : CameraScript
{
    float player_xPosition;
    FloorTxt Ft;
    SoundManager sound;
    new void Start()
    {
        sound = SoundManager.inst;
        sound.bgmSource.Stop();
        sound.monsterWalkingSource.Stop();
        sound.monsterGrowlingSource.Stop();
        sound.playerHeartBeatSource.Stop();
        base.Start();
        Ft = FindObjectOfType<FloorTxt>();
        player.currRoom = "B5_Hallway";
        saveData.currFloor = "B5";
        saveData.currRoomPos = "복도";
        data.Save();
        Ft.PosUI();
    }

    void Update()
    {
        player_xPosition = mainCharacter.transform.position.x;
        
        //복도일 때
        if (player.currRoom == "B5_Hallway")
        {
            CameraLimit(8.9f, 48.4f);
        }
        
        //처음 단상에 올라왔을 때
        else if (player.currRoom == "OnEstradeatFirst")
        {
            //플레이어 x값이 48.4 안넘어가면 카메라가 플레이어 따라다니게
            if(player_xPosition < 48.4f)
            {
                this.transform.SetParent(cameraParent.transform);
                this.transform.position = new Vector3(player_xPosition, 0.3f, -10);
            }
            //넘어가면 카메라 고정
            else
            {
                this.transform.SetParent(cameraParent.transform);
                this.transform.position = new Vector3(48.4f, 0.3f, -10);
            }
        }
        //"Estrade_immovable" = 단상 올라온 상태 && 플레이어 이동 불가능
        //"Estrade_Movable" = 단상 올라온 상태 && 플레이어 이동 가능
        else if(player.currRoom == "Estrade_immovable" || player.currRoom == "Estrade_Movable")
        {
            this.transform.SetParent(cameraParent.transform);
            this.transform.position = new Vector3(48.4f, 0.3f, -10);
        }
    }
}