//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

public class B2ObjManager : Interactable
{
//    public GameObject hallwayObj;
//    public GameObject cabinetObj;
//    public GameObject galleryObj;
//    public GameObject player;
//    public GameObject locker;
//    public B2_UIManager uiManager;
//    B2_ItemManager itemManager;
//    public GameObject candleUI, statueUI, statueSpUI, cabinet1UI, cabinet2UI, cabinet3UI, cabinet4UI, cabinet5UI, bodyUI, clockUI, frame1UI, frame2UI, frame3UI, frame4UI, poetryUI;
//    public GameObject key1UI, sword1UI, doorToB3;
//    public Text inputTextUI;
//    public Text candleText, statueText, cabinet1Text, cabinet2Text, cabinet4Text, bodyText, frame1Text, frame2Text, frame3Text, frame4Text, poetryText, key1Text;
//    public Text sword1Text;
//    public List<Text> diaryTexts;
//    public List<Text> statueSpTexts;
//    public List<Text> cabinet5Texts;
//    public List<Text> cabinet3Texts;
//    public List<Text> cardkeyTexts;
//    public bool isUnlocked;
//    public Sprite slotSelected;
//    public Sprite slotUnselected;
//    AnsCheck ansCheck;
//    public bool key1Picked = false;
//    B2_Item item;


//    new void Start()
//    {
//        base.Start();
//        uiManager = FindObjectOfType<B2_UIManager>();
//        itemManager = FindObjectOfType<B2_ItemManager>();
//        ansCheck = FindObjectOfType<AnsCheck>();

//    }

//    new void Update()
//    {
//        base.Update(); // Interactable.Update() 불러옴
//        if (hit && hit.collider.tag == "DoorToCabinet" && B2PlayerMng.doorToCabinet)
//        {
//            if (Input.GetKeyDown(KeyCode.Mouse0))
//            {
//                hallwayObj.SetActive(false);
//                cabinetObj.SetActive(true);
//                B2PlayerMng.isOnB2Hallway = false;
//                B2PlayerMng.isOnB2Cabinet = true;
//                player.transform.position = new Vector2(-31.05f, -0.83f);
//            }
//        }
//        else if (hit && hit.collider.tag == "CabinetToHW" && B2PlayerMng.cabinetToHW)
//        {
//            cabinetObj.SetActive(false);
//            hallwayObj.SetActive(true);
//            B2PlayerMng.isOnB2Hallway = true;
//            B2PlayerMng.isOnB2Cabinet = false;
//            player.transform.position = new Vector2(-8.02f, -0.83f);
//            mainCamera.transform.SetParent(player.transform);
//        }
//        else if (hit && hit.collider.tag == "DoorToGallery" && B2PlayerMng.doorToGallery)
//        {
//            if (Input.GetKeyDown(KeyCode.Mouse0))
//            {
//                hallwayObj.SetActive(false);
//                galleryObj.SetActive(true);
//                B2PlayerMng.isOnB2Hallway = false;
//                B2PlayerMng.isOnB2Gallery = true;
//                player.transform.position = new Vector2(7.2f, -0.83f);
//            }

//        }
//        else if (hit && hit.collider.tag == "GalleryToHW" && B2PlayerMng.galleryToHW)
//        {
//            galleryObj.SetActive(false);
//            hallwayObj.SetActive(true);
//            B2PlayerMng.isOnB2Gallery = false;
//            B2PlayerMng.isOnB2Hallway = true;
//            player.transform.position = new Vector2(18.45f, -0.83f);
//            mainCamera.transform.SetParent(player.transform);
//        }
//        else if (hit && hit.collider.tag == "Candle" && B2PlayerMng.candle)
//        {
//            if (Input.GetKeyDown(KeyCode.Mouse0))
//            {
//                candleUI.SetActive(true);
//                StartCoroutine(uiManager.LoadTextOneByOne(candleText.text, inputTextUI));
//            }
//        }
//        else if (hit && hit.collider.tag == "Cabinet1" && B2PlayerMng.cabinet1)
//        {
//            cabinet1UI.SetActive(true);
//            StartCoroutine(uiManager.LoadTextOneByOne(cabinet1Text.text, inputTextUI));
//            //hit.collider.gameObject.SetActive(false);
//            //GameObject itemSlot = itemManager.CheckSlot(itemManager.mufflerItemImg);
//            //itemSlot.tag = "Muffler";
//        }
//        else if (hit && hit.collider.tag == "Cabinet2" && B2PlayerMng.cabinet2)
//        {
//            if (Input.GetKeyDown(KeyCode.Mouse0))
//            {
//                if (key1Picked)
//                {
//                    sword1UI.SetActive(true);
//                    StartCoroutine(uiManager.LoadTextOneByOne(sword1Text.text, inputTextUI));
//                    GameObject itemSlot = itemManager.CheckSlot(itemManager.sword1ItemImg);
//                    itemSlot.tag = "Sword1";
//                }
//                else
//                {
//                    cabinet2UI.SetActive(true);
//                    StartCoroutine(uiManager.LoadTextOneByOne(cabinet2Text.text, inputTextUI));
//                }
//            } 
            
//        }
//        else if (hit && hit.collider.tag == "Cabinet3" && B2PlayerMng.cabinet3)
//        {
//            cabinet3UI.SetActive(true);
//            if (Input.GetKeyDown(KeyCode.Mouse0))
//            {
//                StartCoroutine(uiManager.LoadTexts(cabinet3Texts, inputTextUI, 3));
//                GameObject itemSlot = itemManager.CheckSlot(itemManager.clockitemImg);
//                itemSlot.tag = "Clock";
//            }
//        }
//        else if (hit && hit.collider.tag == "Cabinet4" && B2PlayerMng.cabinet4)
//        {
//            cabinet4UI.SetActive(true);
//            StartCoroutine(uiManager.LoadTextOneByOne(cabinet4Text.text, inputTextUI));
//        }
//        else if (hit && hit.collider.tag == "Cabinet5" && B2PlayerMng.cabinet5)
//        {
//            cabinet5UI.SetActive(true);
//            if (Input.GetKeyDown(KeyCode.Mouse0))
//            {
//                StartCoroutine(uiManager.LoadTexts(cabinet5Texts, inputTextUI, 2));
//            }
//        }
//        else if (hit && hit.collider.tag == "Body" && B2PlayerMng.body)
//        {
//            bodyUI.SetActive(true);
//            if (Input.GetKeyDown(KeyCode.Mouse0))
//                StartCoroutine(uiManager.LoadTextOneByOne(bodyText.text, inputTextUI));
//        }
//        else if (hit && hit.collider.tag == "Statue" && B2PlayerMng.statue)
//        {
//            statueUI.SetActive(true);
//            StartCoroutine(uiManager.LoadTextOneByOne(statueText.text, inputTextUI));
//        }
//        else if (hit && hit.collider.tag == "StatueSp" && B2PlayerMng.statueSp)
//        {
//            statueSpUI.SetActive(true);
//            if (Input.GetKeyDown(KeyCode.Mouse0))
//            {
//                StartCoroutine(uiManager.LoadTexts(statueSpTexts, inputTextUI, 3));
//            }
//        }
//        else if (hit && hit.collider.name == "B2_Frame1" && B2PlayerMng.frame1)
//        {
//            frame1UI.SetActive(true);
//            StartCoroutine(uiManager.LoadTextOneByOne(frame1Text.text, inputTextUI));
//        }
//        else if (hit && hit.collider.name == "B2_Frame2" && B2PlayerMng.frame2)
//        {
//            frame2UI.SetActive(true);
//            StartCoroutine(uiManager.LoadTextOneByOne(frame2Text.text, inputTextUI));
//        }
//        else if (hit && hit.collider.name == "B2_Frame3" && B2PlayerMng.frame3)
//        {
//            frame3UI.SetActive(true);
//            StartCoroutine(uiManager.LoadTextOneByOne(frame3Text.text, inputTextUI));
//        }
//        else if (hit && hit.collider.name == "B2_Frame4" && B2PlayerMng.frame4)
//        {
//            frame4UI.SetActive(true);
//            StartCoroutine(uiManager.LoadTextOneByOne(frame4Text.text, inputTextUI));
    //    }
    //    else if (hit && hit.collider.name == "B2_Poetry" && B2PlayerMng.poetry)
    //    {
    //        poetryUI.SetActive(true);
    //        StartCoroutine(uiManager.LoadTextOneByOne(poetryText.text, inputTextUI));
    //    }
    //    else if (hit && hit.collider.tag == "DoorToB3" && B2PlayerMng.doorToB3)
    //    {
    //        Debug.Log("이제 칼 꽃고 문 여는 애니메이션 만들어야함...");
    //    }
    //}
}

