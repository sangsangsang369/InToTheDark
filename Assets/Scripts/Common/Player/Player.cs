using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Detect
{
    public string currRoom;
    public float speed = 6f;

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

    void AnimationStart(Collider2D collider)
    {
        if(collider.GetComponent<CollisionObject>())
        {
            Debug.Log("됨");
            collider.GetComponent<CollisionObject>().enabled = true;
            CollisionObject collisionObj = collider.GetComponent<CollisionObject>();
            
            if(collisionObj.enabled)
            { 
                collisionObj.CollisionObjectFunction();
            }
        }
    }
}
