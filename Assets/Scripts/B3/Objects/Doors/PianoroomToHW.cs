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
    FloorTxt Ft;

    void Start()
    {
        player = FindObjectOfType<Player>();
        data = DataManager.singleTon;
        saveData = data.saveData;
        Ft = FindObjectOfType<FloorTxt>();
    }

    public override void ObjectFunction()
    {
        hallwayObj.SetActive(true);
        PianoroomObj.SetActive(false);
        player.currRoom = "B3_Hallway";
        saveData.currFloor = "B3";
        saveData.currRoomPos = "복도";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(30.2f, -0.83f);
    }
}

