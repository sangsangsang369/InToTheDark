using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B3_Statue : Object
{
   public GameObject statueUI;
    public Text statueText;
    public Text inputTextUI;
    B3UIManager uiManager;
    bool playB3StatueOnce = false;

    DataManager data;
    SaveDataClass saveData;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        playB3StatueOnce = saveData.playB3StatueOnce;
        uiManager = FindObjectOfType<B3UIManager>();
        if(playB3StatueOnce)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false; 
        }
    }
    private void Update() 
    {
        if(playB3StatueOnce && this.gameObject.GetComponent<BoxCollider2D>().enabled)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false; 
        }
    }

    public override void ObjectFunction()
    {
        if (!playB3StatueOnce)
        {
            statueUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(statueText.text, inputTextUI));
            playB3StatueOnce = true;
            saveData.playB3StatueOnce = true;
            data.Save();
        }
    }
}

