using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToLib : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject libraryObj;
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
        LoadRoom("LoadLibrary");
    }

    void LoadLibrary()
    {
        hallwayObj.SetActive(false); // B1F object 끄기
        libraryObj.SetActive(true); // bg sprite를 복도 -> 서재로 변경
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B1Library];
        player.currRoom = "B1_Library";
        saveData.currFloor = "B1";
        saveData.currRoomPos = "낡은 서재";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(7.0f, -0.83f);
    }
}
