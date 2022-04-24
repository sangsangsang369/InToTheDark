using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterPriestWalk : MonoBehaviour
{
    //사제 걸어나오는 애니메이션 이후 실행되는 스크립트
    //사제 대사 텍스트 나오게

    public GameObject priestUI;
    public List<Text> priestTexts;
    public Text inputTextUI;
    B5_UIManager uiManager;
    public int scptOn = 0;
    SoundManager sound;
    AudioSource priestAudioSource;
    bool noPWalking = false;

     void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        sound = SoundManager.inst;
        priestAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(this.gameObject.GetComponent<Animator>().GetBool("WalkOn") == true
           && !this.gameObject.GetComponent<Animator>().GetBool("HandsUp") == true)
        {
            priestEffectPlay();
        }
        else if(this.gameObject.GetComponent<Animator>().GetBool("HandsUp") == true)
        {
            priestAudioSource.Stop();
        }
    }

    public void PriestScptOn()
    {
        scptOn = 1; 
        priestUI.SetActive(true);
        uiManager.StartCoroutine(uiManager.LoadTexts(priestTexts, inputTextUI, 10));
    }

    public void priestEffectPlay()
    {
        if(noPWalking == false) 
        {
            if(priestAudioSource.isPlaying)
            {
                return;
            }
            else if(!priestAudioSource.isPlaying)
            {
                noPWalking = true;
            }
            priestAudioSource.Play();
        }
    }
}
