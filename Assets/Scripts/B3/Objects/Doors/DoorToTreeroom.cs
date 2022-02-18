using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToTreeroom : Object
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
        hallwayObj.SetActive(false);
        TreeroomObj.SetActive(true);
        player.currRoom = "B3_Treeroom";
        playerObj.transform.position = new Vector2(11.0f, -0.83f);
    }
}
