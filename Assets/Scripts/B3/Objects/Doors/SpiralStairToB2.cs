using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiralStairToB2 : Object
{
    DataManager data;
    SaveDataClass saveData;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        player = FindObjectOfType<Player>();
    }

    public override void ObjectFunction()
    {
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B2rightDoor];
        data.Save();
        SceneManager.LoadScene("B2");
    }
}


