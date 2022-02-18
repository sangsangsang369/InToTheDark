using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToLib : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject libraryObj;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public override void ObjectFunction()
    {
        hallwayObj.SetActive(false); // B1F object 끄기
        libraryObj.SetActive(true); // bg sprite를 복도 -> 서재로 변경
        player.currRoom = "B1_Library";
        playerObj.transform.position = new Vector2(7.0f, -0.83f);
    }
}
