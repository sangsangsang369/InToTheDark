using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3LeftBtn : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    SoundManager sound;

    public GameObject playerObj;
    public GameObject creatureEye;
    public bool OnClick;
    Player player;
    public float limit;
    

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
        if(saveData.currRoomPos == "피투성이 복도")
        {
            LeftLimit(37.7f);
            player.limit = 37.7f;
        }
        else if(saveData.currRoomPos == "거대한 정원")
        {
            LeftLimit(21.6f);
            player.limit = 21.6f;
        }
        else if(saveData.currRoomPos == "합주실")
        {
            LeftLimit(17.4f);
            player.limit = 17.4f;
        }
    }

     private void LeftLimit(float limit)
    {
        if (OnClick && playerObj.transform.position.x > -limit)
        {
            playerObj.transform.position += Vector3.left * player.speed * Time.deltaTime;
            if(saveData.currRoomPos == "합주실")
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

