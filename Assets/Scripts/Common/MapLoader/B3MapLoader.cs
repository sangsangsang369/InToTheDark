using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3MapLoader : MonoBehaviour
{
    [SerializeField] GameObject B3Hallway;
    [SerializeField] GameObject B3TreeRoom;
    [SerializeField] GameObject B3PianoRoom;
    [SerializeField] GameObject doorKeeper;
    DataManager data;
    SaveDataClass saveData;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;

        //Invoke("LoadB3Map", 0.1f);
        LoadB3Map();
        doorKeeper.SetActive(!saveData.isB4DoorOpened);
    }

    void LoadB3Map()
    {
        if(saveData.currRoomPos == "피투성이 복도")
        {
            B3Hallway.SetActive(true);
            B3TreeRoom.SetActive(false);
            B3PianoRoom.SetActive(false);
        }
        else if(saveData.currRoomPos == "거대한 정원")
        {
            B3Hallway.SetActive(false);
            B3TreeRoom.SetActive(true);
            B3PianoRoom.SetActive(false);
        }
        else if(saveData.currRoomPos == "합주실")
        {
            B3Hallway.SetActive(false);
            B3TreeRoom.SetActive(false);
            B3PianoRoom.SetActive(true);
        }
    }
}
