using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoroomToHW : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject PianoroomObj;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        hallwayObj.SetActive(true);
        PianoroomObj.SetActive(false);
        player.currRoom = "B3_Hallway";
        playerObj.transform.position = new Vector2(30.2f, -0.83f);
    }
}

