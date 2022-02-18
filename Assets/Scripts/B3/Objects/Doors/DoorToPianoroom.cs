using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToPianoroom : Object
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
        hallwayObj.SetActive(false);
        PianoroomObj.SetActive(true);
        player.currRoom = "B3_Pianoroom";
        playerObj.transform.position = new Vector2(-1.3f, -0.83f);
    }
}