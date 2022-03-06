using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuePuzzle3 : Object
{
    B2_UIManager uiManager;
    Player player;
    public bool statue3Fliped = false;

    DataManager data;
    SaveDataClass saveData;
    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        statue3Fliped = saveData.statue3Fliped;

        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!statue3Fliped)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                statue3Fliped = true;
                saveData.statue3Fliped = true;
                data.Save();
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                statue3Fliped = false;
                saveData.statue3Fliped = false;
                data.Save();
            }
        }
    }
}

