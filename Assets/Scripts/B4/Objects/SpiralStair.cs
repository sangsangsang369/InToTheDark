using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiralStair : Object
{
    DataManager data;
    SaveDataClass saveData;

    public GameObject playerObj;
    Player player;
    FloorTxt Ft;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        player = FindObjectOfType<Player>();
        Ft = FindObjectOfType<FloorTxt>();
    }

    public override void ObjectFunction()
    {
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B3rightDoor];
        saveData.currFloor = "B3";
        saveData.currRoomPos = "피투성이 복도";
        data.Save();
        Ft.PosUI();
        LoadScene("B3");
    }
}
