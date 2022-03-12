using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Detect
{
    DataManager data;
    SaveDataClass saveData;

    public string currRoom;
    public float speed = 6f;
    [HideInInspector] public float limit;

    new void Start()
    {
        base.Start();
        data = DataManager.singleTon;
        saveData = data.saveData;
        
        this.transform.position = new Vector2(saveData.playerXstartPoint, this.transform.position.y);
        FindObjectOfType<CameraScript>().CameraSetting();
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
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.GetComponent<Object>())
        {
            collider.GetComponent<Object>().enabled = false;
        }
        MagnifierTrigger(collider, false);
    }

    private void MagnifierTrigger(Collider2D col, bool boolean)
    {
        GameObject activatedObj = col.gameObject;
        if(activatedObj.transform.childCount != 0)
        {
            Transform magnifier = activatedObj.transform.GetChild(0);
            magnifier.gameObject.SetActive(boolean);
        }
    }
}
