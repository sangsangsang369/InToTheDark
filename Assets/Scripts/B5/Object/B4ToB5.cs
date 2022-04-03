using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B4ToB5 : Object
{
    DataManager data;
    SaveDataClass saveData;

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
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B4rightDoor];
        saveData.currFloor = "B4";
        saveData.currRoomPos = "이형체의 복도";
        data.Save();
        LoadScene("B4");
    }
}


