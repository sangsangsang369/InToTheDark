using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToCabinet : Object
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

    // Start is called before the first frame update
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
        LoadRoom("LoadCabinet", inst.doorOpenEffect);
    }

    void LoadCabinet()
    {
        hallwayObj.SetActive(false);
        cabinetObj.SetActive(true);
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B2CabinetRoom];
        player.currRoom = "B2_Cabinet";
        saveData.currFloor = "B2";
        saveData.currRoomPos = "시체의 방";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(-31.05f, -0.83f); // 시작지점
    }
}
