using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SubstractNum : MonoBehaviour
{
    public Text numberText;
    int num;
    
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        numberText.text = num.ToString();
    }

    public void SubNumber()
    {
        num = Int32.Parse(numberText.text);
        if(num != 0)
        {
            num--;
            numberText.text = num.ToString();
        }
        else
        {
            num = 9;
            numberText.text = num.ToString();
        }
    }
}
