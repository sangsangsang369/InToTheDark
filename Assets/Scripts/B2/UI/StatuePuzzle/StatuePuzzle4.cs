using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuePuzzle4 : Object
{
    B2_UIManager uiManager;
    Player player;
    public bool statue4Fliped = false;
    SoundManager SM;
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
            if (!statue4Fliped)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                SM.EffectPlay(SM.swipeStatueEffect);
                statue4Fliped = true;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                SM.EffectPlay(SM.swipeStatueEffect);
                statue4Fliped = false;
            }
        }
    }
}

