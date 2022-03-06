using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiralStair : Object
{
    DataManager data;
    SaveDataClass saveData;

    public GameObject playerObj;
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
        SceneManager.LoadScene("B3");
        saveData.nextScenePlayerPosition = new Vector2(18, -0.83f);
    }
}
