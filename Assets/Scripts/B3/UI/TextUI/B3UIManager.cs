using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class B3UIManager : UI
{
    public GameObject startUI, wrongCombineUI, wrongMaterialUI;
    public Text startText, wrongCombineText, wrongMaterialText;



    // Start is called before the first frame update
    void Start()
    {
        startUI.SetActive(true);
        StartCoroutine(LoadTextOneByOne(startText.text, inputTextUI));
    }
}

