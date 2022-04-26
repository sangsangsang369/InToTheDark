using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 이동에 필요

public class StartScene : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    SceneLoadManager sceneLoader;
    SoundManager inst;
    IntroScpt IntroScpt;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        inst = SoundManager.inst;
        sceneLoader = SceneLoadManager.instance;
        IntroScpt = FindObjectOfType<IntroScpt>();
    }
    
    public void LoadGame() // 버튼 누르면 실행될 함수
    {
        inst.ButtonEffectPlay(inst.buttonOnStartScene);
        data.Load();
        sceneLoader.LoadScene(saveData.currFloor); // ()안에 있는 이름을 가진 씬으로 전환됨
    }

    public void StartNewGame()
    {
        inst.ButtonEffectPlay(inst.buttonOnStartScene);
        data.saveData = new SaveDataClass();
        data.saveData.isFirstPlay = false;
        data.Save();
        IntroScpt.nowstart();
        IntroScpt.introCanvas.SetActive(true);
    }
}
