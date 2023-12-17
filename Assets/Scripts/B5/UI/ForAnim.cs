using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForAnim : MonoBehaviour
{
    B5_UIManager uiManager;
    public GameObject textsUI, preTextUI;
    public Text prevText;
    public GameObject endingCredit, endingCreditParent;
    SoundManager sound;
    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        sound = SoundManager.inst;
    }
    public void SetOnTrigger(){
        prevText.GetComponent<Text>().text = "";
        prevText.gameObject.SetActive(false);
        preTextUI.SetActive(false);
        this.GetComponent<Animator>().SetTrigger("ZoomOut");
        textsUI.SetActive(true);
    }

    public void SetOffPrevText(){
        prevText.gameObject.SetActive(false);
        preTextUI.SetActive(false);
    }

    public void SetOffScpt(){
        textsUI.SetActive(false);
    }


    public void EndingScpt(){
        if(!textsUI.activeSelf)
        {
            sound.BGMStop();
            endingCreditParent.SetActive(true);
            endingCredit.GetComponent<Animator>().SetTrigger("TheEnd");
            EndingBGMOn();
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
