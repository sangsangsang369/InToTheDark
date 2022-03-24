using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1MapLoader : MonoBehaviour
{
    [SerializeField] GameObject B1Hallway;
    [SerializeField] GameObject B1Library;
    DataManager data;
    SaveDataClass saveData;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;

        //Invoke("LoadB1Map", 0.1f);
        LoadB1Map();
    }

    void LoadB1Map()
    {
        if(saveData.currRoomPos == "복도")
        {
            B1Hallway.SetActive(true);
            B1Library.SetActive(false);
        }
        else if(saveData.currRoomPos == "낡은 서재")
        {
            B1Hallway.SetActive(false);
            B1Library.SetActive(true);
        }
    }
}
