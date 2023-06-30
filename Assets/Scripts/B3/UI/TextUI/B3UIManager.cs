using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class B3UIManager : UI
{
    public GameObject startUI, wrongCombineUI, wrongMaterialUI, getLiquidUI;
    public Text startText, wrongCombineText, wrongMaterialText, getLiquidText;
    
    DataManager data;
    SaveDataClass saveData;
    public bool isB3ReEntered;
    public List<Text> pianoroomStatueTexts;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        isB3ReEntered = saveData.isB3ReEntered;

        //이형체 복도에 존재할 때만 스크립트 뜨게
        if(isB3ReEntered == false) 
        {
            startUI.SetActive(true);
            StartCoroutine(LoadTextOneByOne(startText.text, inputTextUI));
            
            isB3ReEntered = true;
            saveData.isB3ReEntered = true;
            data.Save();
        }
    }

     public IEnumerator LoadPianoStatueTexts()
    {
        yield return null;
        for(int i = 0; i < 2; i++)
        {
            while(nowTexting)
            {
                yield return null;
            }
            for(int j = 0; j < 2; j++)
            {
                if(textOrder == j)
                {
                    StartCoroutine(LoadTextOneByOne(pianoroomStatueTexts[j].text, inputTextUI));
                }
            }
            textOrder++;
        }
        textOrder = 0;
    }
}

