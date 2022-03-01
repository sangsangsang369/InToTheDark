using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : CollisionObject
{
    public GameObject priest, priestUI, playerObj;
    Player player;
    public GameObject walls;
    public GameObject floor;
    public GameObject globalLight;
    public GameObject coverCanvas;
    AfterPriestWalk afterPriestWalk;
    int onEstrade = 0;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
        afterPriestWalk = FindObjectOfType<AfterPriestWalk>();
    }
    void Update() 
    {
        if( afterPriestWalk.scptOn == 1 && !priestUI.activeSelf)
        {
            priest.GetComponent<Animator>().SetBool("HandsUp", true);
            afterPriestWalk.scptOn++;
        }
        if(coverCanvas && coverCanvas.activeSelf == true && onEstrade ==0)
        {
            playerObj.GetComponent<Animator>().SetBool("isWalking", false);
            onEstrade = 1;
        }
    }

    public override void CollisionObjectFunction()
    {
        player.currRoom = "Estrade_immovable";
        coverCanvas.SetActive(true);
        globalLight.GetComponent<Animator>().SetBool("LightOff", true);
        floor.SetActive(false);
        walls.GetComponent<Animator>().SetTrigger("Open");
    }
}
