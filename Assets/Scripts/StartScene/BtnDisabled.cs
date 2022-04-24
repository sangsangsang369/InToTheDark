using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDisabled : MonoBehaviour
{
    public Button playbtn, creditbtn, quitbtn;
    public Text play, creadit, quit;
    SoundManager inst;
    private void Start() {
        inst = SoundManager.inst;
    }
    public void SetDisabled()
    {
        inst.ButtonEffectPlay(inst.buttonOnStartScene);
        playbtn.interactable = false;
        creditbtn.interactable = false;
        quitbtn.interactable = false;

        play.color = Color.gray;
        creadit.color = Color.gray;
        quit.color = Color.gray;
        
    }

    public void UnDisabled()
    {
        inst.ButtonEffectPlay(inst.buttonOnStartScene);
        playbtn.interactable = true;
        creditbtn.interactable = true;
        quitbtn.interactable = true;

        play.color = Color.white;
        creadit.color = Color.white;
        quit.color = Color.white;
        
    }
}
