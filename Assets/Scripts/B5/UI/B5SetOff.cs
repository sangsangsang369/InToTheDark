using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B5SetOff : MonoBehaviour
{
    B5_UIManager uiManager;
    Text inputTextUI;
    MonsterBro monsterBro;
    

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        monsterBro = FindObjectOfType<MonsterBro>();
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
    
    public void OffAndOptionOn()
    {
        if (!uiManager.nowTexting)
        {
            this.gameObject.SetActive(false);
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            uiManager.Option();
        }
    }

    public void OffAndMonsterBroMove()
    {
        if (!uiManager.nowTexting)
        {
            this.gameObject.SetActive(false);
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            monsterBro.monsterBroTrigger_Muf = true;
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
}