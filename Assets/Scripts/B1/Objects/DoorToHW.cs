using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToHW : Object
{
    public GameObject playerObj;
    public GameObject hallwayObj;
    public GameObject libraryObj;
    Player player;
    Camera mainCamera;

    void Start()
    {
        player = FindObjectOfType<Player>();
        mainCamera = FindObjectOfType<Camera>();
    }

    public override void ObjectFunction()
    {
        libraryObj.SetActive(false); // bg sprite를 복도 -> 서재로 변경
        hallwayObj.SetActive(true); // B1F object 끄기
        player.currRoom = "B1_Hallway";
        playerObj.transform.position = new Vector2(-7.7f, -0.83f);
        mainCamera.transform.SetParent(player.transform);
    }
}
