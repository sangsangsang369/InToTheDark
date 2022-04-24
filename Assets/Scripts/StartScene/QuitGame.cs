using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    SoundManager inst;

    private void Start() {
        inst = SoundManager.inst;
    }
    // Start is called before the first frame update
    public void GameOff()
    {
        inst.ButtonEffectPlay(inst.buttonOnStartScene);
        Application.Quit();
    }
}
