using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOff : MonoBehaviour
{
    UI uiManager;
    Text inputTextUI;
    SceneLoadManager sceneLoader;
    
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UI>();
        inputTextUI = uiManager.inputTextUI;
        sceneLoader = SceneLoadManager.instance;
    }

    public void prefabScrptOff(GameObject inputTextUI)
    {
        if(!uiManager.nowTexting)
        {
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    public void Off()
    {
        if(!uiManager.nowTexting)
        {
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    void Reset()
    {
        inputTextUI.GetComponent<Text>().text = "";
        inputTextUI.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void OffAfterMoment()
    {
        if(!uiManager.nowTexting)
        {
            Invoke("Reset", 0.3f);
        }
    }

    public void OffAndLoadObject(GameObject obj)
    {
        if(!uiManager.nowTexting)
        {
            uiManager.numOfClicked++;
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            if(uiManager.numOfClicked == 1)
            {
                obj.SetActive(true);
                uiManager.numOfClicked = 0;
            }
            this.gameObject.SetActive(false);
        }
    }

    public void OffAndLoadScene(string sceneName)
    {
        if(!uiManager.nowTexting)
        {
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            SoundManager.inst.EffectPlay(SoundManager.inst.stairEffect);
            sceneLoader.LoadScene(sceneName);
        }
    }
}
