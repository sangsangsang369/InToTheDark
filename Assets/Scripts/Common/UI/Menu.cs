using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    SoundManager inst;
    SceneLoadManager sceneLoader;

    private Button TapOpenBtn, TapCloseBtn, ResumeBtn, SettingsBtn, MainBtn;
    public static bool GameIsPaused = false;
    public GameObject MenuCanvas, pauseTap, settingTap;
    public Text Floor;
    public Slider BGM, SFX;

    private void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        inst = SoundManager.inst;
        sceneLoader = SceneLoadManager.instance;
        // BGM.value = saveData.volume1;
        // SFX.value = saveData.volume2;
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
        BGM.value = saveData.volume1;
        SFX.value = saveData.volume2;
    }
    
    public void Mains() // 스타트 화면으로 돌아가기
    {
        if (GameIsPaused)
        {
            Time.timeScale = 1f;
            sceneLoader.LoadScene("Start");
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

    public void MuteAllBtn()
    {
        inst.bgmSource.volume = 0;
        inst.effectSource.volume = 0;
        inst.buttonSource.volume = 0;
        inst.playerAudioSource.volume = 0;
        inst.monsterAudioSource.volume = 0;
        BGM.value = 0;
        SFX.value = 0;
    }

    public void ApplyBtn()
    {
        saveData.volume1 = inst.bgmSource.volume;
        saveData.volume2 = inst.effectSource.volume;
        saveData.volume2 = inst.buttonSource.volume;
        saveData.volume2 = inst.playerAudioSource.volume;
        saveData.volume2 = inst.monsterAudioSource.volume;
        data.Save();
    }
    
}
