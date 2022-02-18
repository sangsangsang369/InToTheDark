using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LabToHW : Object
{
    public GameObject playerObj;
    public GameObject labObj;
    public GameObject hallwayObj;
    public Light2D globalLight;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public override void ObjectFunction()
    {
        labObj.SetActive(false);
        hallwayObj.SetActive(true);
        globalLight.intensity = 0.05f;
        player.currRoom = "B4_Hallway";
        playerObj.transform.position = new Vector2(29.9f, -0.83f);
    }
}
