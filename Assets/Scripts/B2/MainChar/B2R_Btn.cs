using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2R_Btn : MonoBehaviour
{
    public GameObject player;
    bool OnClick;
    Player playerMng;

    void Start()
    {
        playerMng = FindObjectOfType<Player>();
    }

    // 매 프레임마다 작동
    void Update()
    {
        if (playerMng.currRoom == "B2_Hallway")
        {
            if (OnClick && player.transform.position.x < 37.7) 
            {
                player.transform.position += Vector3.right * playerMng.speed * Time.deltaTime; //me.deltaTime=한 프레임이 처리될때 소요된 시간 반환)
            }
        }
        else if (playerMng.currRoom == "B2_Cabinet")
        {
            if (OnClick && player.transform.position.x < -19.65) 
            {
                player.transform.position += Vector3.right * playerMng.speed * Time.deltaTime; 
            }
        }
        else if (playerMng.currRoom == "B2_Gallery")
        {
            if (OnClick && player.transform.position.x < 9.45)
            {
                player.transform.position += Vector3.right * playerMng.speed * Time.deltaTime;
            }
        }
    }
    public void RightBtnUp() //버튼에서 손 뗐을 때
    {
        OnClick = false; //OnClick false됨
        player.GetComponent<Animator>().SetBool("isWalking", false);
    }
    public void RightBtnDown() //버튼 눌렸을 때
    {
        OnClick = true; //OnClick true됨
        player.GetComponent<Animator>().SetBool("isWalking", true);
        //playerMng.raycastDir = new Vector3(1, 0, 0); //레이저 방향을 오른쪽으로 설정
        player.GetComponent<SpriteRenderer>().flipX = false;
    }
}
