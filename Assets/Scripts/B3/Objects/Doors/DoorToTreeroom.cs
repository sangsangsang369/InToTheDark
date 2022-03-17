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

    void Start()
    {
        player = FindObjectOfType<Player>();
        data = DataManager.singleTon;
        saveData = data.saveData;
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        hallwayObj.SetActive(false);
        TreeroomObj.SetActive(true);
        player.currRoom = "B3_Treeroom";
        saveData.currFloor = "B3";
        saveData.currRoomPos = "트리룸";
        data.Save();
        playerObj.transform.position = new Vector2(11.0f, -0.83f);
    }
}
