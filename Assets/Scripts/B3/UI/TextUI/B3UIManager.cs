using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class B3UIManager : UI
{
    public GameObject startUI, wrongCombineUI, wrongMaterialUI;
    public Text startText, wrongCombineText, wrongMaterialText;
    
    DataManager data;
    SaveDataClass saveData;
    public bool isMonsterDisappear = false;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        isMonsterDisappear = saveData.isMonsterDisappear;

        //이형체 복도에 존재할 때만 스크립트 뜨게
        if(isMonsterDisappear == false) 
        {
            startUI.SetActive(true);
            StartCoroutine(LoadTextOneByOne(startText.text, inputTextUI));
        }
    }
}

