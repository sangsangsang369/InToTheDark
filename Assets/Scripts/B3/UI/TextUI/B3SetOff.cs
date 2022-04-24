using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class B3SetOff : MonoBehaviour
{
    B3UIManager uiManager;
    PianoMng pianoMng;

    Text inputTextUI;
    DataManager data;
    SaveDataClass saveData;
    FloorTxt Ft;
    SceneLoadManager sceneLoader;

    
    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        uiManager = FindObjectOfType<B3UIManager>();
        pianoMng = FindObjectOfType<PianoMng>();
        Ft = FindObjectOfType<FloorTxt>();
        inputTextUI = uiManager.inputTextUI;
        sceneLoader = SceneLoadManager.instance;
    }

    public void Off()
    {
        if (!uiManager.nowTexting)
        {
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
    public void PianoExplainOff()
    {
        if (!uiManager.nowTexting)
        {
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            pianoMng.pianoMemoUI.SetActive(true);
        }
    }

    public void OffAndLoadScene(string sceneName)
    {
        if(!uiManager.nowTexting)
        { 
            saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B4leftDoor];
            saveData.currRoomPos = "이형체의 복도";
            Ft.PosUI();
            data.Save();
            sceneLoader.LoadScene("B4");
        }
    }
}
