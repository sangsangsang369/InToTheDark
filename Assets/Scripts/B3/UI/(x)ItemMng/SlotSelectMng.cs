using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSelectMng : MonoBehaviour
{
    B3InventoryMng b3inventoryMng;
    LabTableItemManager labtableMng;
    public Sprite slotSelected, slotUnselected; //선택된 슬롯, 선택 안된 슬롯 sprite
    public List<bool> selectCheck = new List<bool>(); //인벤토리 슬롯 선택 여부 체크하는 리스트
    int itemIndex = 0; //해당 아이템 인덱스
    public int trueIndex = 0; //값 true인 원소의 인덱스(=선택된 아이템의 인덱스)
    public bool liquidSelected = false;
    public bool sel = false;
    public GameObject selectitem;

    void Start()
    {
        b3inventoryMng = FindObjectOfType<B3InventoryMng>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
    }
    //인벤토리 슬롯 선택하고 끄는 함수
    public void SlotSelect(GameObject item)
    {
        FindItemIndex(item); //아이템 위치(인덱스) 찾아오기
        selectitem = item;
        //슬롯 아무것도 선택안된 상태에서 최초로 선택할 때

        if(!sel) 
        {
            sel = true;
            item.gameObject.transform.parent.GetComponent<Image>().sprite = slotSelected;
        }
        /*if(!selectCheck.Contains(true))
        {
            trueIndex = itemIndex; 
            selectCheck[trueIndex] = true; //선택된 거 저장하는 리스트에 해당 아이템 true로
            item.gameObject.transform.parent.GetComponent<Image>().sprite = slotSelected; //이미지 선택된 이미지로 바꿔주기
            sel = true;
        } 

        //슬롯에 선택된 것이 있을 때
        else if(selectCheck.Contains(true))
        {
            
            //아이템이랑 이미 선택되어있는 아이템이랑 인덱스 같으면(선택된 거 또 눌렀을 때)
            if(itemIndex == trueIndex)
            {
                selectCheck[trueIndex] = false; //선택된거 false로
                item.gameObject.transform.parent.GetComponent<Image>().sprite = slotUnselected; //이미지 선택 안된 이미지로 바꿔주기
            }
            
            //아이템이랑 이미 선택되어있는 아이템이랑 인덱스 다르면(선택된 거랑 다른거 눌렀을 때)
            else if(itemIndex != trueIndex)
            {
                selectCheck[trueIndex] = false; //선택된 거 false로
                b3inventoryMng.slotList[trueIndex].transform.GetComponent<Image>().sprite = slotUnselected; //전에 선택된거 이미지 바꿔주기
                trueIndex = itemIndex; //선택된 거 인덱스 새롭게 선택된 아이템 인덱스로 바꾸기
                selectCheck[trueIndex] = true; //선택된 거 true로 
                item.gameObject.transform.parent.GetComponent<Image>().sprite = slotSelected; //새롭게 선택된 아이템 이미지 선택된 이미지로 바꿔주기
            }
        }*/
    }

    //슬롯리스트에서 아이템 인덱스 찾는 함수
    public void FindItemIndex(GameObject item)
    {
        for(int i = 0; i < selectCheck.Count; i++)
        {
            if(b3inventoryMng.slotList[i].transform.childCount>0
            && b3inventoryMng.slotList[i].transform.GetChild(0).gameObject == item) 
            {
                itemIndex = i;
                break;                
            }
        }
    }
    
    //인벤토리에서 선택된 거 사용했을 때 시행할 함수
    //인벤토리 선택된거 초기화 && 아이템 파괴
    public void UseSelectItem()
    {
        Destroy(b3inventoryMng.slotList[trueIndex].transform.GetChild(0).gameObject); 
        selectCheck[trueIndex] = false; //선택된 거 false로
        b3inventoryMng.slotList[trueIndex].transform.GetComponent<Image>().sprite = slotUnselected;
        liquidSelected = false;
    }

}

