using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToTreeroom : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject TreeroomObj;
    Player player;
    DataManager data;
    SaveDataClass saveData;
    SoundManager inst;
    FloorTxt Ft; 

    void Start()
    {
        player = FindObjectOfType<Player>();
        data = DataManager.singleTon;
        saveData = data.saveData;
        inst = SoundManager.inst;
        Ft = FindObjectOfType<FloorTxt>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        LoadRoom("LoadTreeroom", inst.doorOpenEffect);
    }

    void LoadTreeroom()
    {
        hallwayObj.SetActive(false);
        TreeroomObj.SetActive(true);
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B3TreeRoom];
        player.currRoom = "B3_Treeroom";
        saveData.currFloor = "B3";
        saveData.currRoomPos = "거대한 정원";
        data.Save();
        Ft.PosUI();
        SoundManager inst = SoundManager.inst;
        inst.monsterWalkingSource.clip = null;
        inst.monsterGrowlingSource.clip = null;
        playerObj.transform.position = new Vector2(11.0f, -0.83f);
    }
}
