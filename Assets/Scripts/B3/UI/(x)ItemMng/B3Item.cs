using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B3Item : MonoBehaviour
{}
/*{
    Player player;
    RaycastHit2D hit;
    B3ObjectManager b3ObjectManager;
    B3ItemManager b3ItemManager;
    
    LabTable labTable;
    Vector3 raycastDir = new Vector3(0, 0, 1);
    Vector3 mousePos;
    Camera mainCamera;
    LabTableItemMng labTableItemMng;
    public bool FleshOnePicked = false;
    public bool leafPatternPicked = false;

    // Start is called before the first frame update
    void Start()
    {
        b3ObjectManager = FindObjectOfType<B3ObjectManager>();
        b3ItemManager = FindObjectOfType<B3ItemManager>();
        player = FindObjectOfType<Player>();
    
        mainCamera = FindObjectOfType<Camera>();
        //hit = detect.hit;
        labTableItemMng = FindObjectOfType<LabTableItemMng>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Input.mousePosition;
            Debug.DrawRay(mousePos, new Vector3(0, 0, 10), Color.red, 0.5f);
            hit = Physics2D.Raycast(mousePos, raycastDir, 10f);
            //Debug.Log(hit.collider.tag);
        }
    }

    public void ItemCheck()
    {
       //실험대 ui 안 켜졌을 때(=인벤의 아이템 클릭하면 설명 뜸)
        if (labTable.labTableUI.activeSelf == false)
        {
            if(hit && hit.collider.gameObject.GetComponent<Object>())
            {
                Object obj = hit.collider.gameObject.GetComponent<Object>();
                obj.ObjectFunction();
            }
            if (hit.collider.tag == "Fruit")
            {
                fruit.fruitUI.SetActive(true);
                fruit.StartCoroutine(b3ObjectManager.uiManager.LoadTextOneByOne(b3ObjectManager.fruitText.text, b3ObjectManager.inputTextUI));
            }
            else if (hit.collider.tag == "Branch")
            {
                b3ObjectManager.branchUI.SetActive(true);
                b3ObjectManager.StartCoroutine(b3ObjectManager.uiManager.LoadTextOneByOne(b3ObjectManager.branchText.text, b3ObjectManager.inputTextUI));
            }
            else if (hit.collider.tag == "Treesap")
            {
                b3ObjectManager.treesapUI.SetActive(true);
                b3ObjectManager.StartCoroutine(b3ObjectManager.uiManager.LoadTextOneByOne(b3ObjectManager.treesapText.text, b3ObjectManager.inputTextUI));
            }
            else if (hit.collider.tag == "Leaf")
            {
                b3ObjectManager.leafUI.SetActive(true);
                b3ObjectManager.StartCoroutine(b3ObjectManager.uiManager.LoadTextOneByOne(b3ObjectManager.leafText.text, b3ObjectManager.inputTextUI));
            }
            else if (hit.collider.tag == "FleshOne")
            {
                if (!FleshOnePicked)//이거 그냥 함수 만드는게 나을듯
                {
                    FleshOnePicked = true;
                    this.transform.parent.GetComponent<Image>().sprite = b3ObjectManager.slotSelected;
                }
                else
                {
                    FleshOnePicked = false;
                    this.transform.parent.GetComponent<Image>().sprite = b3ObjectManager.slotUnselected;
                }
            }
            else if (hit.collider.tag == "LeafPattern")
            {

            }
        } 
        
        //실험대 ui 켜졌을 때(=인벤의 아이템 누르면 재료 슬롯으로 들어감 && 재료 슬롯이 꽉 차지 않았을 때)
        if (labTable.labTableUI.activeSelf==true&&!labTableItemMng.leftActive||!labTableItemMng.rightActive)
        {
            if (hit.collider.tag == "Fruit") //열매 누르면
            {
                labTableItemMng.InsertMaterial(labTableItemMng.fruitItemImg, "Fruit"); //재료 슬롯에 삽입
                b3ItemManager.HideSlot("Fruit");  //인벤의 열매 숨기기
                labTableItemMng.fruitActive = true;  //실험대에 올라온 거 체크
            }
            if (hit.collider.tag == "Branch")
            {
                labTableItemMng.InsertMaterial(labTableItemMng.branchItemImg, "Branch");
                b3ItemManager.HideSlot("Branch");
                labTableItemMng.branchActive = true;
            }
            if (hit.collider.tag == "Treesap")
            {
                labTableItemMng.InsertMaterial(labTableItemMng.treesapItemImg, "Treesap");
                b3ItemManager.HideSlot("Treesap");
                labTableItemMng.treesapActive = true;
            }
            if (hit.collider.tag == "Leaf")
            {
                labTableItemMng.InsertMaterial(labTableItemMng.leafItemImg, "Leaf");
                b3ItemManager.HideSlot("Leaf");
                labTableItemMng.leafActive = true;
            }
            if (hit.collider.tag == "FleshOne")
            {
                labTableItemMng.InsertMaterial(labTableItemMng.fleshOneItemImg, "FleshOne");
                b3ItemManager.HideSlot("FleshOne");
                labTableItemMng.fleshOneActive = true;
            }
            if (hit.collider.tag == "LeafPattern")
            {
                labTableItemMng.InsertMaterial(labTableItemMng.leafpatternImg, "LeafPattern");
                b3ItemManager.HideSlot("LeafPattern");
                labTableItemMng.leafpatternActive = true;
            }
          /*if (hit.collider.tag == "Muffler")
            {
                objectManager.mufflerUI.SetActive(true);
                objectManager.StartCoroutine(objectManager.uiManager.LoadTextOneByOne(objectManager.mufflerText.text, objectManager.inputTextUI));
            }
            else if (hit.collider.tag == "Letter")
            {
                objectManager.letterUI.SetActive(true);
            }
            else if (hit.collider.tag == "Note")
            {
                objectManager.noteUI.SetActive(true);
            }
        }
    }
}*/

