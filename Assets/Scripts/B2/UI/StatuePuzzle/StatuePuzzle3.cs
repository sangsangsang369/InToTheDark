﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuePuzzle3 : Object
{
    B2_UIManager uiManager;
    Player player;
    public bool statue3Fliped = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!statue3Fliped)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                statue3Fliped = true;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                statue3Fliped = false;
            }
        }
    }
}

