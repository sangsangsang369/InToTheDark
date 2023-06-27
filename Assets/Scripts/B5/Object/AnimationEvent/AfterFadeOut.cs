﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterFadeOut : MonoBehaviour
{
    //화면 페이드아웃 되고 실행되는 스크립트
    //엔딩 텍스트 띄움

    public GameObject nextText, prevText, endingCredit, endingCreditParent;
    SoundManager sound;
    void Start()
    {
        sound = SoundManager.inst;
    }
    
    public void TextOn() // 엔딩텍스트재생 -> 분기선택에 따라 다르게 띄우기 + 텍스트랑 ui도 동시 재생
    {
        //sound.EndingPlay();
        if(nextText && !endingCredit)
        {
            if(prevText)
            {
                prevText.GetComponent<Animator>().SetBool("textOn",false);
                prevText.SetActive(false);
            }
            nextText.SetActive(true);
            nextText.GetComponent<Animator>().SetBool("textOn",true);
        }  
        else if(!nextText && endingCredit && endingCreditParent)
        {
            endingCreditParent.SetActive(true);
            endingCredit.GetComponent<Animator>().SetTrigger("TheEnd");
        }
    }

    public void EndingBGMOn()
    {
        if (sound.effectSource.clip == sound.endingBGM)
        {
            return;
        }
        sound.EffectPlay(sound.endingBGM);
    }
}
