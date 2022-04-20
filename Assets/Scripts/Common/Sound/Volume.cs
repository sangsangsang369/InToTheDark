using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    SoundManager inst;
    public Slider BGMslider, SFXslider;

    private void Start() 
    {
        inst = SoundManager.inst;
        data = DataManager.singleTon;
        saveData = data.saveData;
        BGMslider.value = saveData.volume1;
        SFXslider.value = saveData.volume2;
    }
    public void BGMControl()
    {
        inst = SoundManager.inst;
        inst.bgmSource.volume = BGMslider.value;
    }

    public void SFXControl()
    {
        inst = SoundManager.inst;
        inst.effectSource.volume = SFXslider.value;
        inst.buttonSource.volume = SFXslider.value;
        inst.playerAudioSource.volume = SFXslider.value;
        inst.playerHeartBeatSource.volume = SFXslider.value;
        inst.monsterGrowlingSource.volume = SFXslider.value;
        inst.monsterWalkingSource.volume = SFXslider.value;
        inst.conversationAudioSource.volume = SFXslider.value;
    }
}

