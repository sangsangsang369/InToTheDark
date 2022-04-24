using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryToHW : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject cabinetObj;
    public GameObject galleryObj;
    Player player;
    DataManager data;
    SaveDataClass saveData;
    SoundManager inst;
    FloorTxt Ft;

    void Start()
    {
        player = FindObjectOfType<Player>();
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
        galleryObj.SetActive(false);
        hallwayObj.SetActive(true);
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B2rightDoor];
        player.currRoom = "B2_Hallway";
        saveData.currFloor = "B2";
        saveData.currRoomPos = "복도";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(18.45f, -0.83f); // 시작지점
    }
}
