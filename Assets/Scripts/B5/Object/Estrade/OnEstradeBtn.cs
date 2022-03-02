using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEstradeBtn : Object
{
    //올라오기 버튼 스크립트

    public GameObject playerObj;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update() 
    {
        if(player.currRoom == "OnEstradeatFirst")
        {
            Destroy(this.gameObject);
        }    
    }
   public override void ObjectFunction()
   {
       //Debug.Log("올라옴");
       player.currRoom = "OnEstradeatFirst";
       playerObj.transform.position =  new Vector3 (player.transform.position.x, 0.3f, player.transform.position.z);
   }
}
