using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2L_Btn : MonoBehaviour
{
    public GameObject player;
    bool OnClick;
    Player playerMng;

    void Start()
    {
        playerMng = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMng.currRoom == "B2_Hallway")
        {
            LeftLimit(37.7f);
        }
        else if (playerMng.currRoom == "B2_Cabinet")
        {
            LeftLimit(47.63f);
        }
        else if (playerMng.currRoom == "B2_Gallery")
        {
            LeftLimit(13.0f); 
        }
    }
    private void LeftLimit(float limit)
    {
        if (OnClick && player.transform.position.x > -limit)
        {
            player.transform.position += Vector3.left * playerMng.speed * Time.deltaTime;
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


