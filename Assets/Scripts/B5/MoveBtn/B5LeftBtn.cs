using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B5LeftBtn : MonoBehaviour
{
    public GameObject playerObj;
    bool OnClick;
    Player player;
    SoundManager sound;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        sound = SoundManager.inst;
    }

    void Update()
    {
        if (player.currRoom == "B5_Hallway")
        {
            LeftLimit(0);
        }
        else if (player.currRoom == "Estrade_immovable")
        {
            //못 움직이게 리밋 설정 x
        }
        else if (player.currRoom == "Estrade_Movable" || player.currRoom == "OnEstradeatFirst")
        {
            LeftLimit(45.8f);
        }
    }

    private void LeftLimit(float limit)
    {
        if (OnClick && playerObj.transform.position.x > limit)
        {
            playerObj.transform.position += Vector3.left * player.speed * Time.deltaTime;
        }
    }
    public void LeftBtnUp()
    {
        sound.playerAudioSource.Stop();
        sound.playerAudioSource.clip = null;
        OnClick = false;
        player.GetComponent<Animator>().SetBool("isWalking", false);
    }
    public void LeftBtnDown()
    {
        sound.playerWalkEffectPlay();
        OnClick = true;
        player.GetComponent<Animator>().SetBool("isWalking", true);
        player.GetComponent<SpriteRenderer>().flipX = true;
    }
}
