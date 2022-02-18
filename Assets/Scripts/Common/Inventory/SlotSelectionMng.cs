using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSelectionMng : MonoBehaviour
{
    //각 씬의 하이라키 창에 요 스크립트 붙은 오브젝트 꼭 생성해주세요!!(B3의 SlotSelectManager 복붙해주세요!!)
    //안 그럼 널레퍼 뜨더라구요!!ㅜ

    //선택된 아이템을 가져오는 변수
    public GameObject selectedItem;
    public Sprite selectedSlotImg, unselectedSlotImg;

    //사용해야 되는 아이템(카드키, B2 칼 등)과 사용 당하는 오브젝트(B2문, 실험실 문 등)간의 상호작용시 사용
    //liquid.cs랑 DoorToB4.cs 참고해주세용
    public string usableItem = null;     
    public List<string> usableItems = new List<string>();    

    public void SelectSlot(GameObject item)
    {
        item.transform.parent.GetComponent<Image>().sprite = selectedSlotImg; //이미지 바꿔주기
        selectedItem = item; //선택된 아이템 selectedItem에 담기
    }  
    public void UnselectSlot(GameObject item)
    {
        item.transform.parent.GetComponent<Image>().sprite = unselectedSlotImg; //이미지 바꿔주기
        selectedItem = null; //선택된 아이템 초기화
        usableItem = null; 
        usableItems.Clear();
    }
}

