using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioMixer BGMmixer, SFXmixer;
    public Slider BGMslider, SFXslider;

    private void Start()
    {
        float sound = BGMslider.value;
        sound = PlayerPrefs.GetFloat("BGM only", 0.75f);
    }

    public void BGMControl(float sliderValue1)
    {
        BGMmixer.SetFloat("BGM only", Mathf.Log10(sliderValue1) * 20);
        PlayerPrefs.SetFloat("BGM only", sliderValue1);
    }

    public void SFXControl(float silderValue2)
    {
        SFXmixer.SetFloat("SFX only", Mathf.Log10(silderValue2) * 20);
        PlayerPrefs.SetFloat("SFX only", silderValue2);
    }

}

