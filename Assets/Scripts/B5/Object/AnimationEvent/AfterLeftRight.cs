using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterLeftRight : MonoBehaviour
{
    //주인공 왼쪽 오른쪽 왔다갔다 애니메이션 이후 실행
    //이형체 걸어오게 함

    public GameObject monsterBro;
    public GameObject fadeOut;
    bool monsterBroTrigger = false;
    public GameObject floorTxt;
    SoundManager sound;

    void Start()
    {
        sound = SoundManager.inst;
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
        if (monsterBroTrigger && monsterBro.transform.position.x < 44)
        {
            monsterBro.GetComponent<Animator>().SetBool("isWalking", true);
            monsterBro.transform.position += Vector3.right * 0.8f * Time.deltaTime;
            floorTxt.SetActive(false);
            fadeOut.SetActive(true);
            fadeOut.GetComponent<Animator>().SetBool("fadeOut", true);
            Invoke("PlayScreamSound",0.5f);
        }
    }

    private void PlayScreamSound()
    {
        sound.playerScreamEffectPlay();
    }
}
