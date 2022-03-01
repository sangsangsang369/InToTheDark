using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDoorOpen : MonoBehaviour
{
    //벽 열리고 실행되는 스크립트 
    //사제 걸어나오게 함

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
        if(priest.transform.position.x > 54)
        {
            priest.GetComponent<Animator>().SetBool("WalkOn", true);
            priest.transform.position += Vector3.left * 2.0f * Time.deltaTime;
        } 
    }
    
}
