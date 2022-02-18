using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B3SetOff : MonoBehaviour
{
    B3UIManager uiManager;
    PianoMng pianoMng;

    Text inputTextUI;
    
    // Start is called before the first frame update
    void Start()
    {
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
}
