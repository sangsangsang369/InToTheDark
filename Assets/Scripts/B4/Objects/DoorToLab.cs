using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DoorToLab : Object
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
        hallwayObj.SetActive(false);
        labObj.SetActive(true);
        globalLight.intensity = 0.66f;
        player.currRoom = "B4_Lab";
        saveData.currFloor = "B4";
        saveData.currRoomPos = "수상한 실험실";
        data.Save();
        Ft.PosUI();
        playerObj.transform.position = new Vector2(1.5f, -0.83f);
    }
}
