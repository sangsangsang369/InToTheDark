using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Detect
{
    DataManager data;
    SaveDataClass saveData;
    SoundManager inst;

    public string currRoom;
    public float speed = 6f;
    [HideInInspector] public float limit;

    new void Start()
    {
        base.Start();
        data = DataManager.singleTon;
        saveData = data.saveData;
        inst = SoundManager.inst;
        
        this.transform.position = new Vector2(saveData.playerXstartPoint, this.transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<CollisionObject>())
        {
            collider.GetComponent<CollisionObject>().CollisionObjectFunction();
        }
        else
        {
            if(collider.GetComponent<Object>())
            {
                collider.GetComponent<Object>().enabled = true;
            }
            MagnifierTrigger(collider, true);
        }
        //이형체와 닿으면 죽는거
        if(collider.GetComponent<Monster>())
        {
            if(!collider.GetComponent<Monster>().areYouDied)
            {
                WhenYouDied(collider);
            }
            if(collider.GetComponent<Monster>().GetComponent<Animator>().enabled)
            {
                collider.GetComponent<Monster>().GetComponent<Animator>().enabled = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.GetComponent<Object>())
        {
            collider.GetComponent<Object>().enabled = false;
        }
        MagnifierTrigger(collider, false);
    }

    void MagnifierTrigger(Collider2D col, bool boolean)
    {
        GameObject activatedObj = col.gameObject;
        if(activatedObj.transform.childCount != 0)
        {
            Transform magnifier = activatedObj.transform.GetChild(0);
            magnifier.gameObject.SetActive(boolean);
        }
    }

    void WhenYouDied(Collider2D collider)
    {
        inst.playerAudioSource.Stop();
        GetComponent<Animator>().SetBool("isWalking", false);
        collider.GetComponent<Monster>().areYouDied = true;
        collider.GetComponent<Monster>().leftBtn.SetActive(false);
        collider.GetComponent<Monster>().rightBtn.SetActive(false);
        collider.GetComponent<Monster>().leftBtnImg.SetActive(true);
        collider.GetComponent<Monster>().rightBtnImg.SetActive(true);
    }
}
