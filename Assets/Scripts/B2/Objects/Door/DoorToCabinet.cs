using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToCabinet : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject cabinetObj;
    public GameObject galleryObj;
    Player player;
    DataManager data;
    SaveDataClass saveData;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        data = DataManager.singleTon;
        saveData = data.saveData;
    }

    public override void ObjectFunction()
    {
        hallwayObj.SetActive(false);
        cabinetObj.SetActive(true);
        player.currRoom = "B2_Cabinet";
        saveData.currFloor = "B2";
        saveData.currRoomPos = "캐비닛룸";
        data.Save();
        playerObj.transform.position = new Vector2(-31.05f, -0.83f); // 시작지점
    }
}
