using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class B5RightBtn : MonoBehaviour
{
    public GameObject playerObj;
    bool OnClick;
    Player player;
    SoundManager sound;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
        sound = SoundManager.inst;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currRoom == "B5_Hallway")
        {
            RightLimit(56.9f);
        }
        else if (player.currRoom == "Estrade_immovable")
        {
            //못 움직이게 리밋 설정 x
        }
        else if(player.currRoom == "Estrade_Movable"|| player.currRoom == "OnEstradeatFirst")
        {
            RightLimit(50.6f);
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
        sound.playerAudioSource.Stop();
        sound.playerAudioSource.clip = null;
        OnClick = false;
        player.GetComponent<Animator>().SetBool("isWalking", false);
    }
    public void RightBtnDown()
    {
        sound.playerWalkEffectPlay();
        OnClick = true;
        player.GetComponent<Animator>().SetBool("isWalking", true);
        player.GetComponent<SpriteRenderer>().flipX = false;
    }
}
