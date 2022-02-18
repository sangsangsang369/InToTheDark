using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ra : PianoKey
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
        pianoMng.KeyInputsList.Add("Ra");
    }

    public void RaFunction() 
    {
        pianoMng.CompareKeys(this.gameObject);
    }
}
