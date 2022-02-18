using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B5RightBtn : MonoBehaviour
{
    public GameObject playerObj;
    bool OnClick;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currRoom == "B5_Hallway")
        {
            RightLimit(-655.3f);
        }
        else if (player.currRoom == "Estrade")
        {
            RightLimit(-655.3f);
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
