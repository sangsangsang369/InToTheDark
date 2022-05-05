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
    public GameObject MenuCanvas, pauseTap, settingTap, LastTap;
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
        inst.ButtonEffectPlay(inst.buttonEffect);
        MenuCanvas.SetActive(true);
        Floor.text = saveData.currFloor + " - " + saveData.currRoomPos;
        pauseTap.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseTap() // 메뉴 전체 창 닫기 -> 쓸 일 없을 듯
    {
        inst.ButtonEffectPlay(inst.buttonEffect);
        if (MenuCanvas)
        {
            MenuCanvas.SetActive(false);
            pauseTap.SetActive(true);
        }
    }
    
    public void Resume() // 게임 재개
    {
        inst.ButtonEffectPlay(inst.buttonEffect);
        Time.timeScale = 1f;
        MenuCanvas.SetActive(false);
    }

    public void Settings() // 사운드 셋팅 창 열기
    {
        inst.ButtonEffectPlay(inst.buttonEffect);
        BGM.value = saveData.volume1;
        SFX.value = saveData.volume2;
    }
    
    public void LastQ()
    {
        inst.ButtonEffectPlay(inst.buttonEffect);
        LastTap.SetActive(true);
        pauseTap.SetActive(false);
    }
    public void NoBtn()
    {
        inst.ButtonEffectPlay(inst.buttonEffect);
        pauseTap.SetActive(true);
        LastTap.SetActive(false);
    }
    public void Mains() // 스타트 화면으로 돌아가기
    {
        inst.ButtonEffectPlay(inst.buttonEffect);
        inst.monsterGrowlingSource.Stop();
        inst.monsterWalkingSource.Stop();
        Time.timeScale = 1f;
        sceneLoader.LoadScene("Start");
    }

    public void BackBtn() //사운드 셋팅 창 -> 메뉴 전체 창으로 돌아가기
    {
        inst.ButtonEffectPlay(inst.buttonEffect);
        settingTap.SetActive(false);
        pauseTap.SetActive(true);
    }

    public void MuteAllBtn()
    {
        inst.ButtonEffectPlay(inst.buttonEffect);
        inst.bgmSource.volume = 0;
        inst.effectSource.volume = 0;
        inst.buttonSource.volume = 0;
        inst.playerAudioSource.volume = 0;
        inst.playerHeartBeatSource.volume = 0;
        inst.monsterGrowlingSource.volume = 0;
        inst.monsterWalkingSource.volume = 0;
        inst.conversationAudioSource.volume = 0;
        inst.itemSource.volume = 0;
        BGM.value = 0;
        SFX.value = 0;
    }

    public void ApplyBtn()
    {
        inst.ButtonEffectPlay(inst.buttonEffect);
        saveData.volume1 = inst.bgmSource.volume;
        saveData.volume2 = inst.effectSource.volume;
        saveData.volume2 = inst.buttonSource.volume;
        saveData.volume2 = inst.playerAudioSource.volume;
        saveData.volume2 = inst.playerHeartBeatSource.volume;
        saveData.volume2 = inst.monsterGrowlingSource.volume;
        saveData.volume2 = inst.monsterWalkingSource.volume;
        saveData.volume2 = inst.conversationAudioSource.volume;
        saveData.volume2 = inst.itemSource.volume;
        data.Save();
    }
    
}
