using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorToB5 : Object
{
    DataManager data;
    SaveDataClass saveData;

    UI uiManager;
    [SerializeField] private GameObject doorToB5UI;
    [SerializeField] private Text doorToB5Text;
    [SerializeField] private Text inputTextUI;
    [HideInInspector] public bool isB5DoorOpened;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        isB5DoorOpened = saveData.isB5DoorOpened;

        uiManager = FindObjectOfType<UI>();
        if(isB5DoorOpened)
        {
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public override void ObjectFunction()
    {
        if(!isB5DoorOpened)
        {
            doorToB5UI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(doorToB5Text.text, inputTextUI));
        }
        else
        {
            saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B5leftDoor];
            saveData.currFloor = "B5";
            saveData.currRoomPos = "복도";
            data.Save();
            LoadScene("B5");
        }
    }
}