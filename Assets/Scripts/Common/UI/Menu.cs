using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;

    private Button TapOpenBtn, TapCloseBtn, ResumeBtn, SettingsBtn, MainBtn;
    public static bool GameIsPaused = false;
    public GameObject MenuCanvas, pauseTap, settingTap;
    public Text Floor;

    private void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
    }

    public void OpenTap() // 메뉴 전체 창 열기
    {
        MenuCanvas.SetActive(true);
        Floor.text = saveData.currFloor + " - " + saveData.currRoomPos;
        pauseTap.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void CloseTap() // 메뉴 전체 창 닫기 -> 쓸 일 없을 듯
    {
        if (MenuCanvas)
        {
            MenuCanvas.SetActive(false);
            pauseTap.SetActive(true);
        }
    }
    
    public void Resume() // 게임 재개
    {
        if (GameIsPaused)
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
            MenuCanvas.SetActive(false);
            pauseTap.SetActive(false);
        }
    }

    public void Settings() // 사운드 셋팅 창 열기
    {
        if (GameIsPaused)
        {
            settingTap.SetActive(true);
            pauseTap.SetActive(false);
        }
    }
    
    public void Mains() // 스타트 화면으로 돌아가기
    {
        if (GameIsPaused)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Start");
        }
    }

    public void BackBtn() //사운드 셋팅 창 -> 메뉴 전체 창으로 돌아가기
    {
        if (GameIsPaused)
        {
            settingTap.SetActive(false);
            pauseTap.SetActive(true);
        }
    }

    public void ApplyBtn()
    {
        // 사운드 설정 바꾼거 적용하기
    }
    
}
