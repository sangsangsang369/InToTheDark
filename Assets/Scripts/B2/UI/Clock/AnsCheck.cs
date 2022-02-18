using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnsCheck : MonoBehaviour
{
    MoveHand moveHour;
    MoveMin moveMin;
    B2_UIManager uiManager;
    public B2_InventoryManager inventoryMng;
    public GameObject Img1, Img2, Img3, Img4;
    public GameObject Imgs;
    public Button checkBtn;
    public int ImgNum = 1;
    //public bool isClockOpen = false;
    public GameObject key1UI, clockUI, keyImg;
    public Text key1Text;
    public Text inputTextUI;


    // Start is called before the first frame update
    void Start()
    {
        moveHour = FindObjectOfType<MoveHand>();
        moveMin = FindObjectOfType<MoveMin>();
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<B2_InventoryManager>();
        checkBtn.onClick.AddListener(delegate{ CheckAnswer(); });
    }

    public void CheckAnswer()
    {
        if (ImgNum == 1)
        {
            if ((moveHour.firstHour == true) && (moveMin.firstMin == true))
            {
                Imgs.GetComponent<Animator>().SetTrigger("GoOn");
                ImgNum = 2;
            }
        }
        if (ImgNum == 2)
        {
            
            if ((moveHour.secHour == true) && (moveMin.secMin == true))
            {
                Img1.SetActive(false);
                Imgs.GetComponent<Animator>().SetTrigger("GGoOn");
                ImgNum = 3;
            }
        }
        if (ImgNum == 3)
        {
            if ((moveHour.thrHour == true) && (moveMin.thrMin == true))
            {
                Img2.SetActive(false);
                Imgs.GetComponent<Animator>().SetTrigger("GGGoOn");
                ImgNum = 4;
            }
        }
        if (ImgNum == 4)
        {
            if ((moveHour.fourHour == true) && (moveMin.fourMin == true))
            {
                Img3.SetActive(false);
                Invoke("ClockOpen", 0.5f);
            }
        }
    }

    public void ClockOpen()
    {
        key1UI.SetActive(true);
        uiManager.StartCoroutine(uiManager.LoadTextOneByOne(key1Text.text, inputTextUI));
        clockUI.SetActive(false);
        GameObject cabinetKey = keyImg;
        inventoryMng.AddToInventory(cabinetKey);
    }
}
