using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToChapel : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject chapelObj;
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

    public override void ObjectFunction()
    {
        LoadRoom("LoadChapel", inst.doorOpenEffect);
    }

    void LoadChapel()
    {
        hallwayObj.SetActive(false);
        chapelObj.SetActive(true);
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B4Chapel];
        player.currRoom = "B4_Chapel";
        saveData.currFloor = "B4";
        saveData.currRoomPos = "예배당";
        data.Save();
        Ft.PosUI();
        SoundManager inst = SoundManager.inst;
        inst.monsterWalkingSource.clip = null;
        inst.monsterGrowlingSource.clip = null;
        playerObj.transform.position = new Vector2(-10.9f, -0.83f);
    }
}
