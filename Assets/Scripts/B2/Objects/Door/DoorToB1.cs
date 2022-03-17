using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToB1 : Object
{
    DataManager data;
    SaveDataClass saveData;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        player.currRoom = "B1_Hallway";
        saveData.currFloor = "B1";
        saveData.currRoomPos = "복도";
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B1rightDoor];
        data.Save();
        SceneManager.LoadScene("B1");
    }
}
