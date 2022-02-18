using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public GameObject playerObj;
    bool OnClick;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.currRoom == "B4_Hallway")
        {
            LeftLimit(37.7f);
        }
        else if(player.currRoom == "B4_Chapel")
        {
            LeftLimit(13.5f);
        }
        else if(player.currRoom == "B4_Lab")
        {
            LeftLimit(17.3f);
        }
    }

    private void LeftLimit(float limit)
    {
        if (OnClick && playerObj.transform.position.x > -limit)
        {
            playerObj.transform.position += Vector3.left * player.speed * Time.deltaTime;
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
        player.GetComponent<SpriteRenderer>().flipX = true;
    }
}
