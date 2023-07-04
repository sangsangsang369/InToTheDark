using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionTool : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    [SerializeField]
    GameObject optionPanel, mufBtn, knifeBtn;

    public bool haveMuf, haveKnife = false;


    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        haveKnife = saveData.isDaggerPicked;
        haveMuf = saveData.isMufflerPicked;
    }

    public void MufBtnOn(){
        if(haveMuf)
        {
            optionPanel.SetActive(true);
            mufBtn.SetActive(true);
        }
    }

    public void KnifeBtnOn(){
        if(haveKnife)
        {
            optionPanel.SetActive(true);
            knifeBtn.SetActive(true);
        }
    }
}
