using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
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
            RightLimit(37.7f);
        }
        else if(player.currRoom == "B4_Chapel")
        {
            RightLimit(13.5f);
        }
        else if(player.currRoom == "B4_Lab")
        {
            RightLimit(17.3f);
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
