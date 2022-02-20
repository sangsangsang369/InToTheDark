using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3LeftBtn : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject creatureEye;
    public bool OnClick;
    Player player;
    public float limit;
    

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.currRoom == "B3_Hallway")
        {
            LeftLimit(37.7f);
            player.limit = 37.7f;
        }
        else if(player.currRoom == "B3_Treeroom")
        {
            LeftLimit(21.6f);
            player.limit = 21.6f;
        }
        else if(player.currRoom == "B3_Pianoroom")
        {
            LeftLimit(17.4f);
            player.limit = 17.4f;
        }
        /*if (B3playerMng.isOnHallway)  //복도일때
        {
            if (OnClick && player.transform.position.x > -37.7)
            {
                player.transform.position += Vector3.left * B3playerMng.speed * Time.deltaTime;
            }
        }
        else if(B3playerMng.isOnTreeroom)  //트리룸일때
        {
            if (OnClick && player.transform.position.x > -21.6)
            {
                player.transform.position += Vector3.left * B3playerMng.speed * Time.deltaTime;
            }
        }
        else if (B3playerMng.isOnPianoroom)   //피아노룸일때
        {
            if (OnClick && player.transform.position.x > -17.4)
            {
                player.transform.position += Vector3.left * B3playerMng.speed * Time.deltaTime;
            }
            if (OnClick && player.transform.position.x > -13 && player.transform.position.x < 11)
            {
                creatureEye.transform.position += Vector3.left * B3playerMng.speed/ 8 * Time.deltaTime;
                
            }
        }*/
    }

     private void LeftLimit(float limit)
    {
        if (OnClick && playerObj.transform.position.x > -limit)
        {
            playerObj.transform.position += Vector3.left * player.speed * Time.deltaTime;
            if(player.currRoom=="B3_Pianoroom")
            {
                if (OnClick && player.transform.position.x > -13 && player.transform.position.x < 11)
                {
                    creatureEye.transform.position += Vector3.left * player.speed/ 8 * Time.deltaTime;
                }
            }
        }
    }
    public void LeftBtnUp()
    {
        OnClick = false;
        player.GetComponent<Animator>().SetBool("isWalking", false);
    }
    public void LeftBtnDown()
    {
        OnClick = true;
        player.GetComponent<Animator>().SetBool("isWalking", true);
        //playerMng.raycastDir = new Vector3(-1, 0, 0);
        player.GetComponent<SpriteRenderer>().flipX = true;
    }
}

