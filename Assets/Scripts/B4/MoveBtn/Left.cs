using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    SoundManager sound;

    public GameObject playerObj;
    bool OnClick;
    Player player;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        sound = SoundManager.inst;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(saveData.currRoomPos == "이형체의 복도")
        {
            LeftLimit(37.7f);
            player.limit = 37.7f;
        }
        else if(saveData.currRoomPos == "예배당")
        {
            LeftLimit(13.5f);
            player.limit = 13.5f;
        }
        else if(saveData.currRoomPos == "수상한 실험실")
        {
            LeftLimit(17.3f);
            player.limit = 17.3f;
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
