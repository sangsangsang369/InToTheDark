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
                this.gameObject.transform.position += Vector3.right * 1.4f * Time.deltaTime;

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
                monsterBroUI.SetActive(true);
                uiManager.StartCoroutine(uiManager.LoadTextOneByOne(monsterBroText.text, inputTextUI));
                monsterBroTextNum++;
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
