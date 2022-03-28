using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//상은 주석..^^
public class RightBtn : MonoBehaviour
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
        if(saveData.currRoomPos == "복도")
        {
            RightLimit(37.7f);
        }
        else if(saveData.currRoomPos == "낡은 서재")
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
