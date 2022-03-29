using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetToHW : Object
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
        Ft = FindObjectOfType<FloorTxt>();
        player = FindObjectOfType<Player>();
        data = DataManager.singleTon;
        saveData = data.saveData;
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        cabinetObj.SetActive(false);
        hallwayObj.SetActive(true);
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B2leftDoor];
        player.currRoom = "B2_Hallway";
        saveData.currFloor = "B2";
        saveData.currRoomPos = "복도";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(-8.02f, -0.83f); // 시작지점
        //mainCamera.transform.SetParent(player.transform);
    }
}
