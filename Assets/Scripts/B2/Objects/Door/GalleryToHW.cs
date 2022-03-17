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

    void Start()
    {
        player = FindObjectOfType<Player>();
        data = DataManager.singleTon;
        saveData = data.saveData;
    }

    public override void ObjectFunction()
    {
        galleryObj.SetActive(false);
        hallwayObj.SetActive(true);
        player.currRoom = "B2_Hallway";
        saveData.currFloor = "B2";
        saveData.currRoomPos = "복도";
        data.Save();
        playerObj.transform.position = new Vector2(18.45f, -0.83f); // 시작지점
    }
}
