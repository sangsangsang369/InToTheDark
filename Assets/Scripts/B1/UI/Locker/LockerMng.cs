using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LockerMng : MonoBehaviour
{
    [HideInInspector] public int num1, num2, num3, num4 = 0;
    public Text firstNum, secondNum, thirdNum, fourthNum;
    public Button checkNumBtn;
    public GameObject locker;
    public GameObject lockerRing;
    public GameObject diaryUI;
    //ObjectManager objectManager;
    UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        //objectManager = FindObjectOfType<ObjectManager>();
        uiManager = FindObjectOfType<UIManager>();
        //diaryUI = objectManager.diaryUI;
        checkNumBtn.onClick.AddListener(delegate { CheckNumber(); });
    }

    public void CheckNumber()
    {
        num1 = Int32.Parse(firstNum.text);
        num2 = Int32.Parse(secondNum.text);
        num3 = Int32.Parse(thirdNum.text);
        num4 = Int32.Parse(fourthNum.text);

        if(num1 == 8 && num2 == 8 && num3 == 3 && num4 == 7)
        {
            lockerRing.GetComponent<Animator>().SetTrigger("RingTrigger");
            Invoke("Unlock", 1f);
        }
    }

    void Unlock()
    {
        uiManager.isUnlocked = true;
        diaryUI.SetActive(true);
        locker.SetActive(false);
    }
}
