using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSelectionMng : MonoBehaviour
{
    //각 씬의 하이라키 창에 요 스크립트 붙은 오브젝트 꼭 생성해주세요!!(B3의 SlotSelectManager 복붙해주세요!!) 안 그럼 널레퍼 떠요!!

    //선택된 아이템을 가져오는 변수
    public GameObject selectedItem;
    public Sprite selectedSlotImg, unselectedSlotImg;

    //아이템 이름 텍스트
    public Text itemNameTextPrefab;
    public Text itemNameText;
    public string itemName;
    public GameObject inventory;

    //사용해야 되는 아이템(카드키, B2 칼 등)과 사용 당하는 오브젝트(B2문, 실험실 문 등)간의 상호작용시 사용
    //liquid.cs랑 DoorToB4.cs 참고해주세용
    public string usableItem = null;     
    public List<string> usableItems = new List<string>();

    InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void SelectSlot(GameObject item)
    {
        item.transform.parent.GetComponent<Image>().sprite = selectedSlotImg; //이미지 바꿔주기
        selectedItem = item; //선택된 아이템 selectedItem에 담기
        selectedItem.GetComponent<Object>().GetItemName();
        PopItemName();
    }  
    public void UnselectSlot(GameObject item)
    {
        item.transform.parent.GetComponent<Image>().sprite = unselectedSlotImg; //이미지 바꿔주기
        selectedItem = null; //선택된 아이템 초기화
        usableItem = null; 
        usableItems.Clear();
        DestoryItemName();
    }
    //아이템 선택한 상태에서 Destroy(아이템) 해줄 때 같이 써주기 
    public void SelectionClear()
    {
        selectedItem = null; //선택된 아이템 초기화
        usableItem = null; 
        usableItems.Clear();
    }
    //아이템 이름 띄워주기
    public void PopItemName() 
    {
        itemNameTextPrefab.text = itemName; 
        //Debug.Log(itemName);   
        Text name = Instantiate(itemNameTextPrefab);
        itemNameText = name;
        itemNameText.transform.SetParent(inventory.transform);
        itemNameText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 75);
    }
    //아이템 이름 파괴하기
    public void DestoryItemName()
    {
        Destroy(itemNameText.gameObject);
    }
}

