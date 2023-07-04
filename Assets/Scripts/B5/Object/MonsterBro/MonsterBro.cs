using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBro : MonoBehaviour
{
    public GameObject player;
    B5_UIManager uiManager;
    public GameObject monsterBroUI;
    public Text monsterBroText;
    public Text inputTextUI;
    int monsterBroTextNum = 0;
    SoundManager sound;
    public AudioSource monsterAudioSource;

    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        sound = SoundManager.inst;
        monsterAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        MonsterBroWalking(41);
        AfterMonsterBroWalking();
        if(this.gameObject.GetComponent<Animator>().GetBool("isWalking") == true)
        {
            MonsterStepEffectPlay();
        }
        else
        {
            MonsterStepEffectStop();
        }
    }
    private void MonsterBroWalking(float limit)
    {    
        if(this.gameObject.activeSelf == true)
            if (this.gameObject.transform.position.x < limit)
            {
                this.gameObject.GetComponent<Animator>().SetBool("isWalking", true);
                //MonsterStepEffectPlay();
                this.gameObject.transform.position += Vector3.right * 1.5f * Time.deltaTime;

                if(player.transform.position.x < 48)
                {
                    player.GetComponent<Animator>().SetFloat("flip", -1);
                    player.GetComponent<Animator>().SetBool("isWalking", true);
                    sound.playerWalkEffectPlay();
                    player.transform.position += Vector3.right * 0.9f * Time.deltaTime;
                }
                else
                {
                    sound.playerAudioSource.Stop();
                    player.GetComponent<Animator>().SetBool("isWalking", false);
                }
            }
            
            else if(monsterBroTextNum ==0)
            {
                this.gameObject.GetComponent<Animator>().SetBool("isWalking", false);
                //MonsterStepEffectStop();
                monsterBroUI.SetActive(true); // 우리의형제들을위해기도합시다 멘트 뜸
                uiManager.StartCoroutine(uiManager.LoadTextOneByOne(monsterBroText.text, inputTextUI));
                //여기에 선택지 띄움
                //만약에 선택하지 않음이면 숫자증가
                monsterBroTextNum++;

                //단검 선택시,
                // 주인공이 먼저 달려나가는 애니메이션 ㄱㄱ

                // 머플러 선택시,
                // 주인공 대사창 하나 띄우고 기존 애니메이션 재생

                
            }
    }

    private void AfterMonsterBroWalking()
    {
        if(monsterBroUI.activeSelf==false && monsterBroTextNum == 1)        
        {
            player.GetComponent<Animator>().SetBool("leftRight", true);
        }
    }
    public void MonsterStepEffectPlay()
    {
        if(monsterAudioSource.isPlaying)
        {
            return;
        }
        monsterAudioSource.Play();
    }

    public void MonsterStepEffectStop()
    {
        monsterAudioSource.Stop();
    }
}
