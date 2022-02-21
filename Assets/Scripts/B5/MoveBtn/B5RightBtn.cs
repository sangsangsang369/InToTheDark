using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class B5RightBtn : MonoBehaviour
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
        if (player.currRoom == "B5_Hallway")
        {
            RightLimit(37.7f);
        }
        else if (player.currRoom == "Estrade")
        {
            
        }
        else if(player.currRoom == "Estrade_Movable")
        {
            RightLimit(37.7f);
        }
    }
    private void RightLimit(float limit)
    {
        if (OnClick && playerObj.transform.position.x < limit)
        {
            playerObj.transform.position += Vector3.right * player.speed * Time.deltaTime;
        }
    }
    public void RightBtnUp()
    {
        OnClick = false;
        player.GetComponent<Animator>().SetBool("isWalking", false);
    }
    public void RightBtnDown()
    {
        OnClick = true;
        player.GetComponent<Animator>().SetBool("isWalking", true);
        player.GetComponent<SpriteRenderer>().flipX = false;
    }
}
