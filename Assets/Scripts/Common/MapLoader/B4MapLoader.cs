using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4MapLoader : MonoBehaviour
{
    [SerializeField] GameObject B4Hallway;
    [SerializeField] GameObject B4Chapel;
    [SerializeField] GameObject B4Lab;
    DataManager data;
    SaveDataClass saveData;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;

        //Invoke("LoadB4Map", 0.1f);
        LoadB4Map();
    }

    void LoadB4Map()
    {
        if(saveData.currRoomPos == "이형체의 복도")
        {
            B4Hallway.SetActive(true);
            B4Chapel.SetActive(false);
            B4Lab.SetActive(false);
        }
        else if(saveData.currRoomPos == "예배당")
        {
            B4Hallway.SetActive(false);
            B4Chapel.SetActive(true);
            B4Lab.SetActive(false);
        }
        else if(saveData.currRoomPos == "수상한 실험실")
        {
            B4Hallway.SetActive(false);
            B4Chapel.SetActive(false);
            B4Lab.SetActive(true);
        }
    }
}
