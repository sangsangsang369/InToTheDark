using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandPartBtn : MonoBehaviour
{
    SoundManager inst;
    PartOrderMng partOrderMng;
    string partName;

    // Start is called before the first frame update
    void Start()
    {
        inst = SoundManager.inst;
        partOrderMng = FindObjectOfType<PartOrderMng>();
        partName = this.gameObject.name;
    }

    public void PartBtn()
    {
        inst.ButtonEffectPlay(inst.stabButtonEffect);
        if(partOrderMng.answerSheet.Count < 6)
        {
            partOrderMng.answerSheet.Add(partName);
            if(partOrderMng.answerSheet.Count == 6)
            {
                partOrderMng.CheckOrder();
            }
        }
    }

    public void CancelBtn()
    {
        partOrderMng.answerSheet = new List<string>();
    }
}
