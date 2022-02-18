using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : Object

{
    Player player;
    public GameObject monsterBro;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        player.currRoom = "Estrade_afterMonster";
        monsterBro.SetActive(true);
    }
}