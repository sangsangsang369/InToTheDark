using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScpt : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    public GameObject nextText, prevText, introCanvas;
    public bool texton = false;
    //public List<Text> IntroTexts;
    SoundManager sound;
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        sound = SoundManager.inst;
        texton = saveData.texton;
    }
    
    public void TextOnOff()
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
        else if(!nextText)
        {
            introCanvas.SetActive(false);
            texton = true;
            saveData.texton = true;
            data.Save();
        }
    }

    public void IntroOn()
    {
        nextText.SetActive(true);
        nextText.GetComponent<Animator>().SetBool("textOn",true);
    }

    // IEnumerator Typing(Text typingText, string message, float speed) 
    // { 
    //     for (int i = 0; i < message.Length; i++) 
    //     { 
    //         typingText.text = message.Substring(0, i + 1); 
    //         yield return new WaitForSeconds(speed); 
    //     } 
    // } 
}


    

