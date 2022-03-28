using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2R_Btn : MonoBehaviour
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

    // 매 프레임마다 작동
    void Update()
    {
        if (saveData.currRoomPos == "복도")
        {
            if (OnClick && player.transform.position.x < 37.7) 
            {
                player.transform.position += Vector3.right * player.speed * Time.deltaTime; //me.deltaTime=한 프레임이 처리될때 소요된 시간 반환)
            }
        }
        else if (saveData.currRoomPos == "시체의 방")
        {
            if (OnClick && player.transform.position.x < -19.65) 
            {
                player.transform.position += Vector3.right * player.speed * Time.deltaTime; 
            }
        }
        else if (saveData.currRoomPos == "전시실")
        {
            if (OnClick && player.transform.position.x < 9.45)
            {
                player.transform.position += Vector3.right * player.speed * Time.deltaTime;
            }
        }
    }
    public void RightBtnUp() //버튼에서 손 뗐을 때
    {
        sound.playerAudioSource.Stop();
        sound.playerAudioSource.clip = null;
        OnClick = false; //OnClick false됨
        player.GetComponent<Animator>().SetBool("isWalking", false);
    }
    public void RightBtnDown() //버튼 눌렸을 때
    {
        sound.playerWalkEffectPlay();
        OnClick = true; //OnClick true됨
        player.GetComponent<Animator>().SetBool("isWalking", true);
        player.GetComponent<SpriteRenderer>().flipX = false;
    }
}
