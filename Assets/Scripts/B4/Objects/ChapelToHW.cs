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
    FloorTxt Ft;
        

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        data = DataManager.singleTon;
        saveData = data.saveData;
        Ft = FindObjectOfType<FloorTxt>();
    }

    public override void ObjectFunction()
    {
        chapelObj.SetActive(false);
        hallwayObj.SetActive(true);
        player.currRoom = "B4_Hallway";
        saveData.currFloor = "B4";
        saveData.currRoomPos = "이형체의 복도";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(-6.92f, -0.83f);
    }
}
