using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDisabled : MonoBehaviour
{
    [SerializeField] private GameObject startScenePlayer;
    public Button playbtn, creditbtn, quitbtn, continueBtn;
    public Text play, creadit, quit, con;
    SoundManager inst;
    DataManager data;
    SaveDataClass saveData;

    private void Start() 
    {
        inst = SoundManager.inst;
        data = DataManager.singleTon;
        saveData = data.saveData;
        if(saveData.isFirstPlay)
        {
            continueBtn.interactable = false;
            con.color = Color.gray;
        }
        if(saveData.isGameEnded)
        {
            startScenePlayer.SetActive(false);
        }
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
