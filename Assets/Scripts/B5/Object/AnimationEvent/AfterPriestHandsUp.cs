using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPriestHandsUp : MonoBehaviour
{
    //사제 만세 세번 애니메이션 이후 실행되는 스크립트
    //단상 콜라이더 꺼주고 이동 버튼 클릭되게

    Player player;
    public GameObject coverCanvas;
    public GameObject estrade;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void ChangeCurrRoom()
    {
        player.currRoom = "Estrade_Movable";
        estrade.GetComponent<BoxCollider2D>().enabled = false;
        coverCanvas.SetActive(false);
    }
}
