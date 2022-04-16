using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book3 : Object
{
    SoundManager sound;
    public GameObject book3UI;

    void Start()
    {
        sound = SoundManager.inst;
    }

    public override void ObjectFunction()
    {
        sound.EffectPlay(sound.bookSelectEffect);
        book3UI.SetActive(true);
    }
}
