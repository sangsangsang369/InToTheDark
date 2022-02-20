using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDoorOpen : MonoBehaviour
{
    public GameObject priest;
    bool priestTrigger = false;

    private void Update() 
    {
        if(priestTrigger)
        {
            PriestWalk();
        }
    }

    public void PriestWalkTrigger()
    {
        priestTrigger = true;
    }
    public void PriestWalk()
    {
        if(priest.transform.position.x > 34.5)
        {
            priest.GetComponent<Animator>().SetBool("WalkOn", true);
            priest.transform.position += Vector3.left * 2.0f * Time.deltaTime;
        } 
    }
    
}
