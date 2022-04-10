using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEstradeBtn : Object
{
    //올라오기 버튼 스크립트

    public GameObject playerObj, estradeFadeOut;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update() 
    {
        if(player.currRoom == "OnEstradeatFirst")
        {
            this.gameObject.SetActive(false);
        }    
    }
   public override void ObjectFunction()
   {
       estradeFadeOut.SetActive(true);
       estradeFadeOut.GetComponent<Animator>().SetBool("fadeOut_e", true);
       //Debug.Log("올라옴");
       player.currRoom = "OnEstradeatFirst";
       //playerObj.transform.position =  new Vector3 (player.transform.position.x, 0.3f, player.transform.position.z);
   }
}
