﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeroomToHW : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject TreeroomObj;
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

    // Update is called once per frame
    public override void ObjectFunction()
    {
        hallwayObj.SetActive(true);
        TreeroomObj.SetActive(false);
        player.currRoom = "B3_Hallway";
        saveData.currFloor = "B3";
        saveData.currRoomPos = "복도";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(0.8f, -0.83f);
    }
}
