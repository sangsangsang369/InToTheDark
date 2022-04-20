using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2Loader : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    UI uiManager;
    Player player;
    FloorTxt Ft;
    SceneLoadManager sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        uiManager = FindObjectOfType<UI>();
        player = FindObjectOfType<Player>();
        Ft = FindObjectOfType<FloorTxt>();
        sceneLoader = SceneLoadManager.instance;
    }

    public void LoadB2()
    {
        if(!uiManager.nowTexting)
        {
            saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B2leftDoor];
            player.currRoom = "B2_Hallway";
            saveData.currRoomPos = "복도";
            data.Save();
            sceneLoader.LoadScene("B2");
        }
    }
}
