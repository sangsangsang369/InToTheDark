using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LabTableItemMng : MonoBehaviour
{
    B3ItemManager b3ItemManager;

    //실험대슬롯에 들어갈 이미지
    public Sprite fruitItemImg, branchItemImg, treesapItemImg, leafItemImg,fleshOneItemImg,leafpatternImg; 

    //슬롯 오브젝트
    public GameObject itemOne, itemTwo, resultItem; 

    //조합할 때 필요한 bool값(얘가 실험대에 올라갔는지 아닌지 체크)
    public bool fruitActive, branchActive, treesapActive, leafActive, fleshOneActive, leafpatternActive; 

    //실험대의 재료 슬롯에 아이템이 들어갔는지 체크
    public bool leftActive, rightActive, resultItemActive;  

    void Start()
    {
        b3ItemManager = FindObjectOfType<B3ItemManager>(); //이거 안 해주면 널레퍼 뜸
    }

    //재료 슬롯에 아이템 넣고 태그 바꿔주는 함수
    public void InsertMaterial(Sprite itemImage, string itemTag) 
    {
        if (!leftActive)  //왼쪽 슬롯 비었으면
        {
            itemOne.transform.GetChild(0).GetComponent<Image>().sprite = itemImage;  //왼쪽 슬롯의 이미지 바꿔주기
            itemOne.transform.GetChild(0).gameObject.SetActive(true); //이미지 꺼져있던거 켜주기
            itemOne.transform.GetChild(0).gameObject.tag = itemTag;
            leftActive = true; //왼쪽에 아이템 들어감
        }
        else if (leftActive && !rightActive)  //왼쪽 슬롯 찼으면 && 오른쪽 슬롯 비었으면
        {
            itemTwo.transform.GetChild(0).GetComponent<Image>().sprite = itemImage; //오른쪽 슬롯 이미지 바꿔주기
            itemTwo.transform.GetChild(0).gameObject.SetActive(true);
            itemTwo.transform.GetChild(0).gameObject.tag = itemTag;
            rightActive = true; //오른쪽에 아이템 들어감
        }
    }

    //재료 슬롯에 들어온 재료 빼는 함수
    public void UnselectMaterial()
    {
        if (leftActive || rightActive)
        {
            GameObject clickedSlot = EventSystem.current.currentSelectedGameObject;
            if (clickedSlot == itemOne && !resultItemActive)
            {
                clickedSlot.transform.GetChild(0).gameObject.SetActive(false);
                string itemTag = clickedSlot.transform.GetChild(0).gameObject.tag;
                b3ItemManager.ShowHideSlot(itemTag);
                DeactivateMaterial(clickedSlot);
                leftActive = false;
            }
            if (clickedSlot == itemTwo && !resultItemActive)
            {
                clickedSlot.transform.GetChild(0).gameObject.SetActive(false);
                string itemTag = clickedSlot.transform.GetChild(0).gameObject.tag;
                b3ItemManager.ShowHideSlot(itemTag);
                DeactivateMaterial(clickedSlot);
                rightActive = false;
            }
        }
    }

    //결과물 아이템 먹기+실험대 초기화
    public void ResultItemOff()  
    {
        if (resultItem.transform.GetChild(0).gameObject.activeSelf==true) 
        {
            if (resultItem.transform.GetChild(0).gameObject.tag == "FleshOne") 
            {
                b3ItemManager.CheckSlot(fleshOneItemImg,"FleshOne");
                ResetLabTable();
            }
            else if (resultItem.transform.GetChild(0).gameObject.tag == "LeafPattern")
            {
                b3ItemManager.CheckSlot(leafpatternImg, "LeafPattern");
                ResetLabTable();
            }
        }
    }

    //실험대 초기화하는 함수
    public void ResetLabTable()  
    {
        leftActive = false; rightActive = false;  //아이템 들어갔는지 체크한거 초기화
        resultItemActive = false;
        itemOne.transform.GetChild(0).gameObject.SetActive(false);  //재료 슬롯에 이미지 켜준거 꺼주기
        itemTwo.transform.GetChild(0).gameObject.SetActive(false);  
        resultItem.transform.GetChild(0).gameObject.SetActive(false);  //결과물 슬롯도 꺼주기
        b3ItemManager.ShowAllHideSlot();  //숨겨놨던 인벤토리 아이템들 다시 다 켜주기
        DeactivateAllItems();  //실험대에 올라간 아이템 체크한 거 초기화
    }

    //실험대에 올라간 아이템 체크한 거 초기화(아이템 전부 비활성화)
    public void DeactivateAllItems()  
    {
        fruitActive = false;
        branchActive = false;
        treesapActive = false;
        leafActive =false;
        fleshOneActive = false;
        leafpatternActive = false;
    }

    //재료 비활성화 관리 함수
    public void DeactivateMaterial(GameObject Material)
    {
        if (Material.transform.GetChild(0).gameObject.tag == "Fruit") //열매 누르면
        {
            fruitActive = false;  //비활성화
        }
        if (Material.transform.GetChild(0).gameObject.tag == "Branch")
        {
            branchActive = false;
        }
        if (Material.transform.GetChild(0).gameObject.tag == "Treesap")
        {
            treesapActive = false;
        }
        if (Material.transform.GetChild(0).gameObject.tag == "Leaf")
        {
            leafActive = false;
        }
        if (Material.transform.GetChild(0).gameObject.tag == "FleshOne")
        {
            fleshOneActive = false;
        }
        if (Material.transform.GetChild(0).gameObject.tag == "LeafPattern")
        {
            leafpatternActive = false;
        }
    }
}
