using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ra_h :  PianoKey
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
        pianoMng.KeyInputsList.Add("Ra_h");
    }

    public void Ra_hFunction() 
    {
        pianoMng.CompareKeys(this.gameObject);
        SM.PianoKeysPlay(SM.ra_hEffect);
    }
}
