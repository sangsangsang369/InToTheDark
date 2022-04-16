using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book1 : Object
{
    SoundManager sound;
    public GameObject book1UI;

    void Start()
    {
        sound = SoundManager.inst;
    }

    public override void ObjectFunction()
    {
        sound.EffectPlay(sound.bookSelectEffect);
        book1UI.SetActive(true);
    }
}
