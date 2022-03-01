using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : CollisionObject

{
    Player player;
    public GameObject monsterBro, coverCanvas;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public override void CollisionObjectFunction()
    {
        if(player.currRoom == "Estrade_Movable")
        {
            player.currRoom = "Estrade_immovable";
            monsterBro.SetActive(true);
            coverCanvas.SetActive(true);
        }
    }
}