using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOnlyEndingCredit : MonoBehaviour
{
    public GameObject endingCredit, endingCreditParent;
    SoundManager sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = SoundManager.inst;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndingCreditOn()
    {
        endingCreditParent.SetActive(true);
        endingCredit.GetComponent<Animator>().SetTrigger("TheEnd");
        EndingBGMOn();
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
