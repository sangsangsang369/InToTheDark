using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2Loader : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    UI uiManager;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        uiManager = FindObjectOfType<UI>();
    }

    public void LoadB2()
    {
        if(!uiManager.nowTexting)
        {
            saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B2leftDoor];
            data.Save();
        }
    }
}
