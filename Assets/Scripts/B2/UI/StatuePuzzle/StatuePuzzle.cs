using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuePuzzle : Object
{
    B2_UIManager uiManager;
    Player player;
    public bool statue1Fliped = false;

    DataManager data;
    SaveDataClass saveData;
    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        statue1Fliped = saveData.statue1Fliped;

        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!statue1Fliped)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                statue1Fliped = true;
                saveData.statue1Fliped = true;
                data.Save();
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                statue1Fliped = false;
                saveData.statue1Fliped = false;
                data.Save();
            }
        }
    }
}
