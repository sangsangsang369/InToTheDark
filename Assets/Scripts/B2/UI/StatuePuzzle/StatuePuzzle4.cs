using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuePuzzle4 : Object
{
    B2_UIManager uiManager;
    Player player;
    public bool statue4Fliped = false;

    DataManager data;
    SaveDataClass saveData;
    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        statue4Fliped = saveData.statue4Fliped;

        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!statue4Fliped)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                statue4Fliped = true;
                saveData.statue4Fliped = true;
                data.Save();
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                statue4Fliped = false;
                saveData.statue4Fliped = false;
                data.Save();
            }
        }
    }
}

