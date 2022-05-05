using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterEndingCreditUp : MonoBehaviour
{
    public GameObject creditBGBtn; 

    SceneLoadManager sceneLoader;
    DataManager data;
    SaveDataClass saveData;

    private void Start()
    {
        sceneLoader = SceneLoadManager.instance;
        data = DataManager.singleTon;
        saveData = data.saveData;
        creditBGBtn.GetComponent<Button>().enabled = false;
    }

    public void BtnActivate()
    {
        creditBGBtn.GetComponent<Button>().enabled = true;
    }

    public void GoToMainScene()
    {
        saveData.isGameEnded = true;
        data.Save();
        sceneLoader.LoadScene("Start");
        creditBGBtn.GetComponent<Button>().enabled = false;
    }
}
