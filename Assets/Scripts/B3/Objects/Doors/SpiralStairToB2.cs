using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiralStairToB2 : Object
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
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B2rightDoor];
        saveData.currFloor = "B2";
        saveData.currRoomPos = "복도";
        data.Save();
        Ft.PosUI();
        SoundManager inst = SoundManager.inst;
        inst.monsterWalkingSource.clip = null;
        inst.monsterGrowlingSource.clip = null;
        LoadScene("B2");
    }
}


