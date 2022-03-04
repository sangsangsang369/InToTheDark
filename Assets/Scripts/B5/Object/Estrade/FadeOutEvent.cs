using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutEvent : MonoBehaviour
{
    public GameObject playerObj;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void PlayerOnEstrade()
    {
        playerObj.transform.position =  new Vector3 (player.transform.position.x, 0.3f, player.transform.position.z);
    }

    public void EstradeFadeOutCanvasOff()
    {
        this.gameObject.SetActive(false);
    }
}
