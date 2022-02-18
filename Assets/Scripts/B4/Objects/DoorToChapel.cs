using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToChapel : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject chapelObj;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public override void ObjectFunction()
    {
        hallwayObj.SetActive(false);
        chapelObj.SetActive(true);
        player.currRoom = "B4_Chapel";
        playerObj.transform.position = new Vector2(-10.9f, -0.83f);
    }
}
