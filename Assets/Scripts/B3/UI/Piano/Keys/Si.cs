using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Si :  PianoKey
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
        pianoMng.KeyInputsList.Add("Si");
    }

    public void SiFunction() 
    {
        pianoMng.CompareKeys(this.gameObject);
        SM.PianoKeysPlay(SM.siEffect);
    }
}
