using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScpt : MonoBehaviour
{
    public GameObject introCanvas, prevText, nextText;
    public List<Text> introTexts;
    // public string[] introScripts = {"두 달 전, 동생이 집을 나갔다.",
    // "아무리 수소문을 해봐도 동생을 본 사람은 없었다.", 
    // "그러던 중, 경찰서에서 동생을 발견했다는 연락이 왔다.",
    // "CCTV에서  동생은 외딴 건물로 들어갔고, 그 후 자취를 찾을 수 없었다.",
    // "난 동생을 찾아 그 건물로 들어갔다.",
    // "아무 곳에나 있을 법한 작은 예배당이었다.",
    // "천천히 주위를 살피며 앞으로 걸어가는 중, 무언가에 발이 걸려 넘어졌다.",
    // "카펫을 들추니 작은 문 손잡이가 나타났다.",
    // "나는 홀린 듯 그 문을 열고 내려갔다."};
    SoundManager sound;
    SceneLoadManager sceneLoader;
    void Start()
    {
        sound = SoundManager.inst;
        sceneLoader = SceneLoadManager.instance;
    }

    public void nowstart()
    {
        introCanvas.SetActive(true);
        IntroOn();
    }
    
    public void IntroOn()
    {
        if(nextText)
        {
            if(prevText)
            {
                prevText.GetComponent<Animator>().SetBool("TextingOn",false);
                prevText.SetActive(false);
            }
            nextText.SetActive(true);
            nextText.GetComponent<Animator>().SetBool("TextingOn",true);
        } 
        else
        {
            sound.ItemEffectPlaying(sound.stairEffect);
            sceneLoader.LoadScene("B1");
        }
    }
}


    

