using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoroomToHW : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject PianoroomObj;
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
        hallwayObj.SetActive(true);
        PianoroomObj.SetActive(false);
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B3leftDoor];
        player.currRoom = "B3_Hallway";
        saveData.currFloor = "B3";
        saveData.currRoomPos = "피투성이 복도";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(30.2f, -0.83f);
        Monster monster = FindObjectOfType<Monster>();
        monster.MonsterRandomPosition(-32, 35);
        monster.StartCoroutine(monster.RandomDirectionChange());
    }
}

