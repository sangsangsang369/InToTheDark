using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndPos : MonoBehaviour
{
DataManager data;
    SaveDataClass saveData;
    public Text endPos;
    string pos;
    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        pos = "- " + saveData.currFloor + " " + saveData.currRoomPos + " -";
        endPos.text = pos;
    }
}
