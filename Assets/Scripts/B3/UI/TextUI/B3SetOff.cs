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

    
    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        uiManager = FindObjectOfType<B3UIManager>();
        pianoMng = FindObjectOfType<PianoMng>();
        inputTextUI = uiManager.inputTextUI;
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
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            
            saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B4leftDoor];
            data.Save();
            SceneManager.LoadScene("B4");
        }
    }
}
