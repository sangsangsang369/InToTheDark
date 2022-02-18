using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B3ObjectManager : Interactable
{
    public GameObject B3HallwayObj;
    public GameObject TreeroomObj;
    public GameObject PianoroomObj;
    public GameObject player;
    public UIManager uiManager;
    B3ItemManager b3itemManager;
    LabTableItemMng labTableItemMng;
    public GameObject startUI, doorToB4UI, fruitUI, branchUI, treesapUI,leafUI, creatureOnCeilingUI, candleUI, mufflerUI, letterUI, statueUI, labTableUI, labTableExplainUI, labTableCombineUI;
    public Text inputTextUI;
    public Text startText, doorToB4Text, fruitText, branchText, treesapText, leafText, creatureOnCeilingText, candleText, mufflerText, statueText, labTableExplainText, labTableCombineText;
    public List<Text> cardkeyTexts;
    public Sprite slotSelected;
    public Sprite slotUnselected;
    public GameObject fruitGroup;
    public GameObject LabTable; //ui틀면 콜라이더 겹쳐지는 거 땜에 추가 

    public GameObject[] GetChildren(GameObject parent) //게임오브젝트의 자식들 배열로 만드는 함수
    {
        GameObject[] children = new GameObject[parent.transform.childCount];

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            children[i] = parent.transform.GetChild(i).gameObject;
        }

        return children;
    }
    public void LabTableColliderOn() //ui끄면 콜라이더 다시 켜주기
    {
        LabTable.GetComponent<BoxCollider2D>().enabled = true;
    }

    new void Start()
    {
        base.Start();
        uiManager = FindObjectOfType<UIManager>();
        b3itemManager = FindObjectOfType<B3ItemManager>();
        labTableItemMng = FindObjectOfType<LabTableItemMng>();

        startUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(startText.text, inputTextUI));
 
    }

    new void Update()
    {
        base.Update(); // Interactable.Update() 불러옴

        //문 오브젝트
        if (hit && hit.collider.tag == "DoorToTreeroom" && B3playerMng.doorToTreeroom)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                B3HallwayObj.SetActive(false); // B3 복도 끄기
                TreeroomObj.SetActive(true); // 트리룸 키기
                B3playerMng.isOnHallway = false; 
                B3playerMng.isOnTreeroom = true; //트리룸으로 이동
                B3playerMng.isOnPianoroom = false;
                player.transform.position = new Vector2(11.0f, -0.83f);  //문 위치
            }

        }
        else if (hit && hit.collider.tag == "DoorToPianoroom" && B3playerMng.doorToPianoroom)
        {
            PianoroomObj.SetActive(true);   // 피아노룸 키기
            B3HallwayObj.SetActive(false);  // B3 복도 끄기
            B3playerMng.isOnHallway = false;
            B3playerMng.isOnTreeroom = false;
            B3playerMng.isOnPianoroom = true;  //피아노룸으로 이동
            player.transform.position = new Vector2(-1.3f, -0.83f);
        }
        else if (hit && hit.collider.tag == "TreeroomToHW" && B3playerMng.treeroomToHW)
        {
            TreeroomObj.SetActive(false);  // 트리룸 끄기
            B3HallwayObj.SetActive(true);  // B3 복도 키기
            B3playerMng.isOnHallway = true;  //복도로 이동
            B3playerMng.isOnTreeroom = false;
            B3playerMng.isOnPianoroom = false;
            player.transform.position = new Vector2(0.8f, -0.83f);
            mainCamera.transform.SetParent(player.transform);
        }
        else if (hit && hit.collider.tag == "PianoroomToHW" && B3playerMng.pianoroomToHW)
        {
            PianoroomObj.SetActive(false); // 피아노룸 끄기
            B3HallwayObj.SetActive(true);  // B3 복도 키기
            B3playerMng.isOnHallway = true;  //복도로 이동
            B3playerMng.isOnTreeroom = false;
            B3playerMng.isOnPianoroom = false;
            player.transform.position = new Vector2(30.2f, -0.83f);
            mainCamera.transform.SetParent(player.transform);
        }
        else if (hit && hit.collider.tag == "DoorToB4" && B3playerMng.doorToB4)
        {
            doorToB4UI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(doorToB4Text.text, inputTextUI));
        }



        //트리룸 오브젝트
        else if (hit && hit.collider.tag == "Fruit" && B3playerMng.fruit)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                fruitUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(fruitText.text, inputTextUI));
                hit.collider.gameObject.SetActive(false);
                GameObject itemSlot = b3itemManager.CheckSlot(b3itemManager.fruitItemImg);
                itemSlot.tag = "Fruit";

                GameObject[] fruits= GetChildren(fruitGroup);  //TreeroomFruit에 있는 열매 오브젝트를 배열로
                for(int i=0; i < fruitGroup.transform.childCount; i++)  
                {
                    fruits[i].GetComponent<BoxCollider2D>().enabled = false;  //for문 돌면서 배열의 열매 콜라이더 꺼주기
                }
            }
        }
        else if (hit && hit.collider.tag == "Branch" && B3playerMng.branch)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                branchUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(branchText.text, inputTextUI));
                hit.collider.gameObject.SetActive(false);
                GameObject itemSlot = b3itemManager.CheckSlot(b3itemManager.branchItemImg);
                itemSlot.tag = "Branch";
            }
        }
        else if (hit && hit.collider.tag == "Treesap" && B3playerMng.treesap)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                treesapUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(treesapText.text, inputTextUI));
                hit.collider.gameObject.SetActive(false);
                GameObject itemSlot = b3itemManager.CheckSlot(b3itemManager.treesapItemImg);
                itemSlot.tag = "Treesap";
            }
        }
        else if (hit && hit.collider.tag == "Leaf" && B3playerMng.leaf)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                leafUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(leafText.text, inputTextUI));
                hit.collider.gameObject.SetActive(false);
                GameObject itemSlot = b3itemManager.CheckSlot(b3itemManager.leafItemImg);
                itemSlot.tag = "Leaf";
            }
        }
        else if (hit && hit.collider.tag == "LabTable" && B3playerMng.labTable)
        {
            labTableUI.SetActive(true);  //실험대 ui 켜기
            if (labTableUI.activeSelf == true)  //실험대 ui 켜지면
            {
                hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;  //실험대 콜라이더 끄기
            }
           
            labTableExplainUI.SetActive(true);  //실험대 설명 스크립트 on
            StartCoroutine(uiManager.LoadTextOneByOne(labTableExplainText.text, inputTextUI));
        }


        //피아노룸 오브젝트
        else if (hit && hit.collider.tag == "CreatureOnCeiling" && B3playerMng.creatureOnCeiling)
        {
            creatureOnCeilingUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(creatureOnCeilingText.text, inputTextUI));
        }


        //공용 오브젝트
        else if (hit && hit.collider.tag == "Muffler" && playerMng.muffler)
        {
            mufflerUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(mufflerText.text, inputTextUI));
            hit.collider.gameObject.SetActive(false);
            GameObject itemSlot = b3itemManager.CheckSlot(b3itemManager.mufflerItemImg);
            itemSlot.tag = "Muffler";
        }
        else if (hit && hit.collider.tag == "Letter" && playerMng.letter)
        {
            letterUI.SetActive(true);
            hit.collider.gameObject.SetActive(false);
            GameObject itemSlot = b3itemManager.CheckSlot(b3itemManager.letterItemImg);
            itemSlot.tag = "Letter";
        }
        else if (hit && hit.collider.tag == "Candle" && B3playerMng.candle)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                candleUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(candleText.text, inputTextUI));
            }
        }
        else if (hit && hit.collider.tag == "Statue" && B3playerMng.statue)
        {
            statueUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(statueText.text, inputTextUI));
        }
    }
}