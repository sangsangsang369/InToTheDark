using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuePuzzle : Object
{
    B2_UIManager uiManager;
    Player player;
    SoundManager SM;
    public bool statue1Fliped = false;

    // Start is called before the first frame update
    void Start()
    {
        SM = SoundManager.inst;
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!statue1Fliped)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                SM.EffectPlay(SM.swipeStatueEffect);
                statue1Fliped = true;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                SM.EffectPlay(SM.swipeStatueEffect);
                statue1Fliped = false;
            }
        }
    }
}
