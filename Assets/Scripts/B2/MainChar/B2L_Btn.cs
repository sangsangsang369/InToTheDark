using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2L_Btn : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;

    public GameObject playerObj;
    bool OnClick;
    Player player;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (saveData.currRoomPos == "복도")
        {
            LeftLimit(37.7f);
        }
        else if (saveData.currRoomPos == "시체의 방")
        {
            LeftLimit(47.63f);
        }
        else if (saveData.currRoomPos == "전시실")
        {
            LeftLimit(13.0f); 
        }
    }
    private void LeftLimit(float limit)
    {
        if (OnClick && player.transform.position.x > -limit)
        {
            player.transform.position += Vector3.left * player.speed * Time.deltaTime;
        }
    }

    public void LeftBtnUp()
    {
        OnClick = false;
        player.GetComponent<Animator>().SetBool("isWalking", false);
    }
    public void LeftBtnDown()
    {
        OnClick = true;
        player.GetComponent<Animator>().SetBool("isWalking", true);
        //playerMng.raycastDir = new Vector3(-1, 0, 0);
        player.GetComponent<SpriteRenderer>().flipX = true;
    }
}


