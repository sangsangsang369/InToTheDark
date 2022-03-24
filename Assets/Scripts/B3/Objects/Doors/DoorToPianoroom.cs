using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToPianoroom : Object
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

    // Update is called once per frame
    public override void ObjectFunction()
    {
        hallwayObj.SetActive(false);
        PianoroomObj.SetActive(true);
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B3Pianoroom];
        player.currRoom = "B3_Pianoroom";
        saveData.currFloor = "B3";
        saveData.currRoomPos = "합주실";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(-1.3f, -0.83f);
    }
}