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
        labObj.SetActive(false);
        hallwayObj.SetActive(true);
        globalLight.intensity = 0.05f;
        player.currRoom = "B4_Hallway";
        saveData.currFloor = "B4";
        saveData.currRoomPos = "이형체의 복도";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(29.9f, -0.83f);
    }
}
