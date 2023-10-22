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
    public int monsterBroTextNum = 0;
    SoundManager sound;
    public AudioSource monsterAudioSource;
    public AudioClip playerScreamEffect;
    //public AudioClip knifeEffect;

    OptionTool optionTool;
    bool isMonsterbroTextOn = false;
    public bool monsterBroTrigger = false;
    public bool monsterBroTrigger_Muf = false;
    public GameObject KnifeEnding;

    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        optionTool = FindObjectOfType<OptionTool>();
        sound = SoundManager.inst;
        monsterAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        MonsterBroWalking(41);
        AfterMonsterBroWalking();
        MonsterBroWalking_Two();
        MonsterBroWalking_Muffler();
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
                
                if(!isMonsterbroTextOn)
                {
                    monsterBroUI.SetActive(true); // 우리의형제들을위해기도합시다 멘트 뜸
                    isMonsterbroTextOn = true;
                    StartCoroutine(uiManager.LoadTextOneByOne(monsterBroText.text, inputTextUI));
                }
                if(!uiManager.nowTexting)
                {
                    monsterBroUI.SetActive(false);
                    inputTextUI.text = "";
                    optionTool.OptionPanelOn();
                }
                
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

    public void MonsterBroWalking_Muffler()
    {
        if(monsterBroTrigger_Muf)
        {
            this.GetComponent<Animator>().SetBool("isWalking", true);
            this.transform.position += Vector3.right * 0.8f * Time.deltaTime;
            if(this.transform.position.x >= 45f)
            {
                monsterBroTrigger_Muf = false;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void MonsterBroWalking_Two()
    {
        if (monsterBroTrigger)
        {
            this.GetComponent<Animator>().SetBool("isWalking", true);
            this.transform.position += Vector3.right * 0.5f * Time.deltaTime;
            player.GetComponent<Animator>().SetBool("isWalking", true);
            player.transform.position -= Vector3.right * 3f * Time.deltaTime;
            if(player.transform.position.x <= 46f)
            {
                KnifeEnding.SetActive(true);
                monsterBroTrigger = false;
                this.gameObject.SetActive(false);
                sound.ItemEffectPlaying(sound.knifepookEffect);
                sound.EffectPlay(sound.playerScreamEffect);
                
            }
        }
    }
}
