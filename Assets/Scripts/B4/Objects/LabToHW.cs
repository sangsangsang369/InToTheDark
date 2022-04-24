using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LabToHW : Object
{
    public GameObject playerObj;
    public GameObject labObj;
    public GameObject hallwayObj;
    public Light2D globalLight;
    Player player;
    DataManager data;
    SaveDataClass saveData;
    SoundManager inst;
    FloorTxt Ft;

    // Start is called before the first frame update
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
        LoadRoom("LoadHallway", inst.doorUnlockEffect);
    }

    void LoadHallway()
    {
        inst.monsterWalkingSource.volume = saveData.volume2;
        labObj.SetActive(false);
        hallwayObj.SetActive(true);
        globalLight.intensity = 0.05f;
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B4leftDoor];
        player.currRoom = "B4_Hallway";
        saveData.currFloor = "B4";
        saveData.currRoomPos = "이형체의 복도";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(29.9f, -0.83f);
        Monster monster = FindObjectOfType<Monster>();
        monster.MonsterRandomPosition(-32, 35);
        monster.StartCoroutine(monster.RandomDirectionChange());
    }
}
