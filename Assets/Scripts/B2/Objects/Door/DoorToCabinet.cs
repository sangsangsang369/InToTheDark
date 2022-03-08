﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToCabinet : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject cabinetObj;
    public GameObject galleryObj;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public override void ObjectFunction()
    {
        hallwayObj.SetActive(false);
        cabinetObj.SetActive(true);
        player.currRoom = "B2_Cabinet";
        Debug.Log(player.currRoom);
        playerObj.transform.position = new Vector2(-31.05f, -0.83f); // 시작지점
    }
}