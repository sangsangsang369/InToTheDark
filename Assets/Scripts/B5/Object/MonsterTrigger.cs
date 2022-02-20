using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : CollisionObject

{
    Player player;
    Platform platform;
    public GameObject monsterBro;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        platform = FindObjectOfType<Platform>();
    }

    // Update is called once per frame
    public override void CollisionObjectFunction()
    {
        if(player.currRoom == "Estrade")
        {
            player.currRoom = "Estrade_afterMonster";
            monsterBro.SetActive(true);
        }
        
    }
}