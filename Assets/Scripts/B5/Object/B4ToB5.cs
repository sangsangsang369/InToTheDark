using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4ToB5 : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public override void ObjectFunction()
    {
        hallwayObj.SetActive(true);
        player.currRoom = "B5_Hallway";
        Debug.Log(player.currRoom);
        //playerObj.transform.position = new Vector2(); // 시작지점
    }
}
