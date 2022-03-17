using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnsCheck : MonoBehaviour
{
    public MoveHand moveHour;
    public MoveMin moveMin;
    B2_UIManager uiManager;
    [SerializeField] Clock clock;
    public bool isClockOpen = false;
    public InventoryMng inventoryMng;
    public GameObject Img1, Img2, Img3, Img4;
    public GameObject Imgs;
    public Button checkBtn;
    public int ImgNum = 1;
    public GameObject key1UI, clockUI, keyImg;
    public Text key1Text;
    public Text inputTextUI;


    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        clock = FindObjectOfType<Clock>();
        //checkBtn.onClick.AddListener(delegate{ CheckAnswer(); });
    }

    public void CheckAnswer()
    {
        moveHour = FindObjectOfType<MoveHand>();
        moveMin = FindObjectOfType<MoveMin>();
        if (ImgNum == 1)
        {
            if ((moveHour.firstHour == true) && (moveMin.firstMin == true))
            {
                Imgs.GetComponent<Animator>().SetTrigger("GoOn");
                ImgNum = 2;
            }
        }
        else if (ImgNum == 2)
        {
            if ((moveHour.secHour == true) && (moveMin.secMin == true))
            {
                Img1.SetActive(false);
                Imgs.GetComponent<Animator>().SetTrigger("GGoOn");
                ImgNum = 3;
            }
        }
        else if (ImgNum == 3)
        {
            if ((moveHour.thrHour == true) && (moveMin.thrMin == true))
            {
                Img2.SetActive(false);
                Imgs.GetComponent<Animator>().SetTrigger("GGGoOn");
                ImgNum = 4;
            }
        }
        else if (ImgNum == 4)
        {
            if ((moveHour.fourHour == true) && (moveMin.fourMin == true))
            {
                Img3.SetActive(false);
                isClockOpen = true;
                Invoke("ClockOpen", 0.5f);
            }
        }
    }

    public void ClockOpen()
    {
        clock = FindObjectOfType<Clock>();
        inventoryMng.RemoveFromInventory(clock.gameObject, ItemClass.ItemPrefabOrder.PocketWatch);
        inventoryMng.AddToInventory(keyImg, 1f, ItemClass.ItemPrefabOrder.CabinetKey);
        clockUI.SetActive(false);
        key1UI.SetActive(true);
        uiManager.StartCoroutine(uiManager.LoadTextOneByOne(key1Text.text, inputTextUI));
    }
}
