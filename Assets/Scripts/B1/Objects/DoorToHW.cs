using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToHW : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject libraryObj;
    Player player;
    Camera mainCamera;
    DataManager data;
    SaveDataClass saveData;
    SoundManager inst;
    FloorTxt Ft; 

    void Start()
    {
        player = FindObjectOfType<Player>();
        mainCamera = FindObjectOfType<Camera>();
        data = DataManager.singleTon;
        saveData = data.saveData;
        inst = SoundManager.inst;
        Ft = FindObjectOfType<FloorTxt>();
    }

    public override void ObjectFunction()
    {
        LoadRoom("LoadHallway", inst.doorOpenEffect);
    }

    void LoadHallway()
    {
        libraryObj.SetActive(false); // bg sprite를 복도 -> 서재로 변경
        hallwayObj.SetActive(true); // B1F object 끄기
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B2leftDoor];
        player.currRoom = "B1_Hallway";
        saveData.currFloor = "B1";
        saveData.currRoomPos = "복도";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(-7.7f, -0.83f);
        mainCamera.transform.SetParent(player.transform);
    }
}
