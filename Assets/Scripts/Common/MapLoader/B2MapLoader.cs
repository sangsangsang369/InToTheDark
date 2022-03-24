using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2MapLoader : MonoBehaviour
{
    [SerializeField] GameObject B2Hallway;
    [SerializeField] GameObject B2CabinetRoom;
    [SerializeField] GameObject B2Gallery;
    DataManager data;
    SaveDataClass saveData;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;

        //Invoke("LoadB2Map", 0.1f);
        LoadB2Map();
    }

    void LoadB2Map()
    {
        if(saveData.currRoomPos == "복도")
        {
            B2Hallway.SetActive(true);
            B2CabinetRoom.SetActive(false);
            B2Gallery.SetActive(false);
        }
        else if(saveData.currRoomPos == "시체의 방")
        {
            B2Hallway.SetActive(false);
            B2CabinetRoom.SetActive(true);
            B2Gallery.SetActive(false);
        }
        else if(saveData.currRoomPos == "전시실")
        {
            B2Hallway.SetActive(false);
            B2CabinetRoom.SetActive(false);
            B2Gallery.SetActive(true);
        }
    }
}
