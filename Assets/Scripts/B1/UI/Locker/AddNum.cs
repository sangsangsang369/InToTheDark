using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddNum : MonoBehaviour
{
    SoundManager inst;
    public Text numberText;
    int num;
    
    // Start is called before the first frame update
    void Start()
    {
        inst = SoundManager.inst;
        num = 0;
        numberText.text = num.ToString();
    }

    public void AddNumber()
    {
        inst.EffectPlay(inst.lockNumberChangeEffect);
        num = Int32.Parse(numberText.text);
        if(num != 9)
        {
            num++;
            numberText.text = num.ToString();
        }
        else
        {
            num = 0;
            numberText.text = num.ToString();
        }
    }
}
