using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterFadeOut : MonoBehaviour
{

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
