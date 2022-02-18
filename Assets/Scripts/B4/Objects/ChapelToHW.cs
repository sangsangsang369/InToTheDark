using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapelToHW : Object
{
    public GameObject playerObj;
    public GameObject chapelObj;
    public GameObject hallwayObj;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public override void ObjectFunction()
    {
        chapelObj.SetActive(false);
        hallwayObj.SetActive(true);
        player.currRoom = "B4_Hallway";
        playerObj.transform.position = new Vector2(-6.92f, -0.83f);
    }
}
