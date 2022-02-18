using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeroomToHW : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject TreeroomObj;
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
        TreeroomObj.SetActive(false);
        player.currRoom = "B3_Hallway";
        playerObj.transform.position = new Vector2(0.8f, -0.83f);
    }
}
