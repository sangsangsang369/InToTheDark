using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 이동에 필요

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void GameStart() // 버튼 누르면 실행될 함수
    {
        SceneManager.LoadScene("B1"); // ()안에 있는 이름을 가진 씬으로 전환됨
    }
}
