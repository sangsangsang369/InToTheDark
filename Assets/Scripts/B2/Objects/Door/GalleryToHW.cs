using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryToHW : Object
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

    // Update is called once per frame
    public override void ObjectFunction()
    {
        galleryObj.SetActive(false);
        hallwayObj.SetActive(true);
        player.currRoom = "B2_Hallway";
        Debug.Log(player.currRoom);
        playerObj.transform.position = new Vector2(18.45f, -0.83f); // 시작지점
        //mainCamera.transform.SetParent(player.transform);
    }
}
