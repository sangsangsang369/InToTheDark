using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//상은 주석..^^
public class RightBtn : MonoBehaviour
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
        if(player.currRoom == "B1_Hallway")
        {
            RightLimit(37.7f);
        }
        else if(player.currRoom == "B1_Library")
        {
            RightLimit(15.3f);
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
