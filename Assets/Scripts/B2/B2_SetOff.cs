﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B2_SetOff : MonoBehaviour
{
    SoundManager inst;
    B2_UIManager uiManager;
    Text inputTextUI;

    // Start is called before the first frame update
    void Start()
    {
        inst = SoundManager.inst;
        uiManager = FindObjectOfType<B2_UIManager>();
        inputTextUI = uiManager.inputTextUI;
    }

    public void Off()
    {
        if (!uiManager.nowTexting)
        {
            inst.conversationAudioSource.Stop();
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
    public void OffObjects(GameObject obj)
    {
        if(!uiManager.nowTexting)
        {
            uiManager.numOfClicked++;
            inputTextUI.GetComponent<Text>().text = "";
            inputTextUI.gameObject.SetActive(false);
            if(uiManager.numOfClicked == 1)
            {
                obj.SetActive(false);
                uiManager.numOfClicked = 0;
            }
            //this.gameObject.SetActive(false);
        }
    }
}