using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorTxt : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    public Text Floor, Room;
    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
    }

    // Update is called once per frame
    void Update()
    {
        Floor.text = saveData.currFloor;
        Room.text = saveData.currRoomPos;
    }
}
