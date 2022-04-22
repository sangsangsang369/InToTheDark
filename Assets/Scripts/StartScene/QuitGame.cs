using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    SoundManager inst;
    [SerializeField] private AudioClip btnSound;
    private void Start() {
        inst = SoundManager.inst;
    }
    // Start is called before the first frame update
    public void GameOff()
    {
        inst.ButtonEffectPlay(btnSound);
        //Application.Quit();
        Debug.Log("게임이 꺼집니다.");
    }
}
