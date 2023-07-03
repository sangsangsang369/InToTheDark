using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneLoader : MonoBehaviour
{
    [SerializeField] GameObject skipBtn;
    DataManager data;
    SaveDataClass saveData;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;

        if(saveData.isFirstPlay != false){
            skipBtn.SetActive(true);
        }
        else
            skipBtn.SetActive(false);
    }
}
