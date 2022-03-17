using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapelToHW : Object
{
    public GameObject playerObj;
    public GameObject chapelObj;
    public GameObject hallwayObj;
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
        chapelObj.SetActive(false);
        hallwayObj.SetActive(true);
        player.currRoom = "B4_Hallway";
        saveData.currFloor = "B4";
        saveData.currRoomPos = "복도";
        data.Save();
        playerObj.transform.position = new Vector2(-6.92f, -0.83f);
    }
}
