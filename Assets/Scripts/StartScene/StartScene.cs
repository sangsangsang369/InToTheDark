using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 이동에 필요

public class StartScene : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
    }
    
    public void LoadGame() // 버튼 누르면 실행될 함수
    {
        data.Load();
        SceneManager.LoadScene(saveData.currFloor); // ()안에 있는 이름을 가진 씬으로 전환됨
    }

    public void StartNewGame()
    {
        data.saveData = new SaveDataClass();
        data.Save();
        SceneManager.LoadScene("B1");
    }
}
