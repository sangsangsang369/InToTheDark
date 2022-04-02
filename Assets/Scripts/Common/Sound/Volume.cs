using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    //DataManager data;
    //SaveDataClass saveData;
    SoundManager inst;
    public Slider BGMslider, SFXslider;

    private void Start() {
        inst = SoundManager.inst;
    }
    public void BGMControl()
    {
        inst.bgmSource.volume = BGMslider.value;
    }

    public void SFXControl()
    {
        inst.effectSource.volume = SFXslider.value;
        inst.buttonSource.volume = SFXslider.value;
        inst.playerAudioSource.volume = SFXslider.value;
        inst.monsterAudioSource.volume = SFXslider.value;
    }
}

