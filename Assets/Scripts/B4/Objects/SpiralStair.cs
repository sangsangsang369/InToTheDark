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

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        player = FindObjectOfType<Player>();
    }

    public override void ObjectFunction()
    {
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B3rightDoor];
        data.Save();
        saveData.currFloor = "B3";
        saveData.currRoomPos = "복도";
        SceneManager.LoadScene("B3");
    }
}
