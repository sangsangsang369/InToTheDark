using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToGallery : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject cabinetObj;
    public GameObject galleryObj;
    Player player;
    DataManager data;
    SaveDataClass saveData;
    FloorTxt Ft;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        data = DataManager.singleTon;
        saveData = data.saveData;
        Ft = FindObjectOfType<FloorTxt>();
    }

    public override void ObjectFunction()
    {
        LoadRoom("LoadGallery");
    }

    void LoadGallery()
    {
        hallwayObj.SetActive(false);
        galleryObj.SetActive(true);
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B2Gallery];
        player.currRoom = "B2_Gallery";
        saveData.currFloor = "B2";
        saveData.currRoomPos = "전시실";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(7f, -0.83f); // 시작지점
    }
}
