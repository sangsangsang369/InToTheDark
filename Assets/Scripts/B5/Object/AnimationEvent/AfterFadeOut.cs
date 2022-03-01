using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterFadeOut : MonoBehaviour
{
    //화면 페이드아웃 되고 실행되는 스크립트
    //엔딩 텍스트 띄움

    public GameObject nextText, prevText;

    public void TextOn()
    {
        if(nextText)
        {
            if(prevText)
            {
                prevText.GetComponent<Animator>().SetBool("textOn",false);
                prevText.SetActive(false);
            }
            nextText.SetActive(true);
            nextText.GetComponent<Animator>().SetBool("textOn",true);
        }
        
    }
    
}
