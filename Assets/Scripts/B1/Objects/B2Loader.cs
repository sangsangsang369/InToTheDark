using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2Loader : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    UI uiManager;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        uiManager = FindObjectOfType<UI>();
        player = FindObjectOfType<Player>();
    }

    public void LoadB2()
    {
        if(!uiManager.nowTexting)
        {
            saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B2leftDoor];
            player.currRoom = "B2_Hallway";
            saveData.currRoomPos = "B2_Hallway";
            data.Save();
        }
    }
}
