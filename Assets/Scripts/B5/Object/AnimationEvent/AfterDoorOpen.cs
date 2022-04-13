using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDoorOpen : MonoBehaviour
{
    //벽 열리고 실행되는 스크립트 
    //사제 걸어나오게 함

    public GameObject priest;
    bool priestTrigger = false;
    SoundManager sound;

    void Start()
    {
        sound = SoundManager.inst;
    }

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
            // 이거 다시 sound.priestWalkEffectPlay();
            priest.transform.position += Vector3.left * 1.8f * Time.deltaTime;
        } 
    }
    
}
