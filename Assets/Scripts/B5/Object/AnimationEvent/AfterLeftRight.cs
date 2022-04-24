using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterLeftRight : MonoBehaviour
{
    //주인공 왼쪽 오른쪽 왔다갔다 애니메이션 이후 실행
    //이형체 걸어오게 함

    public GameObject monsterBro;
    public GameObject fadeOut;
    public bool monsterBroTrigger = false;
    public GameObject floorTxt;

    bool crowdEffectStopTrigger = false;
    bool screamEffectStopTrigger = false;
    bool noScream = false;
    SoundManager sound;
    public GameObject crowd;
    AudioSource crowdAudioSource;
    public GameObject monster_Bro;
    AudioSource monsterAudioSource;
    
    

    void Start()
    {
        sound = SoundManager.inst;
        crowdAudioSource = crowd.GetComponent<AudioSource>();
        monsterAudioSource = monster_Bro.GetComponent<AudioSource>();
    }
    private void Update() 
    {
       MonsterBroWalking_Two();
    }

    public void MonsterBroWalkTrigger()
    {
        monsterBroTrigger = true;
    }
    private void MonsterBroWalking_Two()
    {
        if (monsterBroTrigger && monsterBro.transform.position.x <= 44)
        {
            monsterBro.GetComponent<Animator>().SetBool("isWalking", true);
            monsterBro.transform.position += Vector3.right * 0.8f * Time.deltaTime;
            floorTxt.SetActive(false);
            fadeOut.SetActive(true);
            fadeOut.GetComponent<Animator>().SetBool("fadeOut", true);
        }
        if (monsterBroTrigger && monsterBro.transform.position.x > 43)
        {
            CrowdEffectStop();
            if(crowdEffectStopTrigger && crowdAudioSource.volume == 0f)
            {
                crowdAudioSource.Stop();
                monsterBro.GetComponent<Animator>().SetBool("isWalking", false);
                Invoke("PlayScreamSound", 0.5f);
            }
        }
    }

    private void PlayScreamSound()
    {
        if(noScream == false) 
        {
            if(sound.effectSource.isPlaying)
            {
                return;
            }
            else if(!sound.effectSource.isPlaying)
            {
                noScream = true;
            }
            sound.EffectPlay(sound.playerScreamEffect);
        }
       
    }
    void CrowdEffectStop()
    {
        crowdEffectStopTrigger = true;
        crowdAudioSource.volume -= Time.deltaTime * 0.3f;
        
    }
}
