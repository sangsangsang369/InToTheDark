using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mi_h : PianoKey
{
    public float AlphaThreshold = 0.1f;
    PianoMng pianoMng;
    SoundManager SM;

    void Start()
    {
        pianoMng = FindObjectOfType<PianoMng>();
        SM = FindObjectOfType<SoundManager>();

        this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
    }

    public override void KeyFunction()
    {
        pianoMng.KeyInputsList.Add("Mi_h");
    }

    public void Mi_hFunction() 
    {
        pianoMng.CompareKeys(this.gameObject);
        SM.PianoKeysPlay(SM.mi_hEffect);
    }
}
