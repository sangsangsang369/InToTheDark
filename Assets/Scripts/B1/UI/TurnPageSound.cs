using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPageSound : MonoBehaviour
{
    SoundManager sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = SoundManager.inst;
    }

    public void turnPageEffectPlay()
    {
        sound.EffectPlay(sound.turnPaperEffect);
    }
}
