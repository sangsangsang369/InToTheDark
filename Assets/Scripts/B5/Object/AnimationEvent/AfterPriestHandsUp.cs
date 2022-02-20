using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPriestHandsUp : MonoBehaviour
{
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
