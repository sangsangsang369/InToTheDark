using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book2 : Object
{
    SoundManager sound;
    public GameObject book2UI;

    void Start()
    {
        sound = SoundManager.inst;
    }

    public override void ObjectFunction()
    {
        sound.EffectPlay(sound.bookSelectEffect);
        book2UI.SetActive(true);
    }
}
