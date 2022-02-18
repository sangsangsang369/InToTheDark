using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Re_h : PianoKey
{
    public float AlphaThreshold = 0.1f;
    PianoMng pianoMng;

    void Start()
    {
        pianoMng = FindObjectOfType<PianoMng>();

        this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
    }

    public override void KeyFunction()
    {
        pianoMng.KeyInputsList.Add("Re_h");
    }

    public void Re_hFunction() 
    {
        pianoMng.CompareKeys(this.gameObject);
    }
}
