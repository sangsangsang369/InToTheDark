using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabTableItemManager : MonoBehaviour
{
    public GameObject itemOne, itemTwo, resultItem; //재료슬롯 1,2 ,결과슬롯 
    public Dictionary<string, bool> itemActive = new Dictionary<string, bool>(); //아이템 활성화 여부(실험대에 올라왔는지) 저장 
    public bool leftActive, rightActive, resultItemActive; //재료슬롯 1,2 , 결과슬롯 비었는지 찼는지 여부
    B3UIManager uiManager;
    InventoryMng inventoryMng; 
    public GameObject labTable; 

    DataManager data;
    SaveDataClass saveData;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        inventoryMng = FindObjectOfType<InventoryMng>();
        uiManager = FindObjectOfType<B3UIManager>();
        AddToDictionary();
    }
    //아이템 활성화 전부 false로 초기화해서 넣어주기
    private void AddToDictionary()
    {
        itemActive.Add("fruitActive", false);
        itemActive.Add("branchActive", false);
        itemActive.Add("treesapActive", false);
        itemActive.Add("leafActive", false);
        itemActive.Add("fleshOneActive", false);
        itemActive.Add("patternLeafActive", false);
        itemActive.Add("monsterExtractActive", false);
        itemActive.Add("fleshTwoActive", false);
        itemActive.Add("liquidActive", false);
    }
    //인벤토리에서 아이템 누르면 재료슬롯에 넣어주는 함수
    public void InsertMaterial(GameObject item) 
    {
        //왼쪽 재료 슬롯 비어있을 때  
        if(!leftActive && !resultItemActive)
        {
            inventoryMng.FilledChecktoFalse(item); //인벤토리에서 해당 위치 filledCheck false로
            item.transform.SetParent(itemOne.transform); //왼쪽 재료슬롯의 자식으로 설정
            leftActive = true; //왼쪽 재료슬롯 활성화
            SetItemSize_Btn(item); //재료슬롯에 맞게 사이즈 조정 & 아이템 버튼 컴포넌트 꺼주기
            item.GetComponent<Object>().ItemActive(); //실험대에 올라왔으니 아이템 활성화
        }
        //왼쪽 슬롯 차있고 오른쪽 슬롯 비어있을 때
        else if (leftActive && !rightActive && !resultItemActive)
        {
            inventoryMng.FilledChecktoFalse(item);
            item.transform.SetParent(itemTwo.transform);
            rightActive = true; 
            SetItemSize_Btn(item);
            item.GetComponent<Object>().ItemActive();
        }        
    }
    //아이템 재료/결과 슬롯 사이즈에 맞게 조정 & 버튼 컴포넌트 꺼주기
    public void SetItemSize_Btn(GameObject item)
    {
        RectTransform itemRT = item.GetComponent<RectTransform>();
        itemRT.anchoredPosition = new Vector2(0, 0);
        itemRT.localScale = new Vector3(0.55f, 0.55f, 1f);
        item.GetComponent<Button>().enabled = false;
    }
    //실험대 위에 올라온 아이템 다시 인벤토리로 넣어주는 함수 (왼쪽 재료슬롯)
    public void UnselectMaterial_Left()
    {
        if(leftActive && !resultItemActive)
        {
            GameObject item = itemOne.transform.GetChild(0).gameObject; //슬롯 자식에 있는 아이템 찾아주기
            inventoryMng.PickUpfromSlot(item); // 인벤토리에 넣어주기
            leftActive = false;  //왼쪽 재료슬롯 비활성화
            item.GetComponent<Button>().enabled = true; //아이템 버튼 컴포넌트 다시 켜주기      
            item.GetComponent<Object>().ItemDeactive(); //실험대에서 내려갔으니 아이템 비활성화
        }
    }  
    //실험대 위에 올라온 아이템 다시 인벤토리로 넣어주는 함수 (오른쪽 재료슬롯)
    public void UnselectMaterial_Right()
    {
        if(rightActive && !resultItemActive)
        {
            GameObject item = itemTwo.transform.GetChild(0).gameObject;
            inventoryMng.PickUpfromSlot(item);
            rightActive = false;  
            item.GetComponent<Button>().enabled = true;
            item.GetComponent<Object>().ItemDeactive();
        }
    }
    //결과 슬롯에서 결과물 아이템 인벤토리에 넣는 함수
    public void GetResultItem()
    {
        if(resultItemActive)
        {
            GameObject item = resultItem.transform.GetChild(0).gameObject;
            inventoryMng.PickUpfromSlot(item);
            resultItemActive = false; //결과슬롯 비활성화
            item.GetComponent<Button>().enabled = true;
            item.GetComponent<Object>().ItemDeactive();
        }
    } 
    //조합 성공했을 때 재료 아이템들 파괴 & 아이템 활성화된거 전부 비활성화로 초기화
    public void DestroyMaterials_ResetActive(ItemClass.ItemPrefabOrder item1Name, ItemClass.ItemPrefabOrder item2Name)
    {
        //Destroy(itemOne.transform.GetChild(0).gameObject);
        //Destroy(itemTwo.transform.GetChild(0).gameObject);
        DestroyOnLabTable(itemOne.transform.GetChild(0).gameObject, item1Name);
        DestroyOnLabTable(itemTwo.transform.GetChild(0).gameObject, item2Name);
        leftActive = false;
        rightActive = false;

        for(int i=0; i< itemActive.Count; i++)
        {
            List<string> keyList = new List<string>(itemActive.Keys);
            string key = keyList[i];
            itemActive[key] = false; 
        }
    }

    private void DestroyOnLabTable(GameObject item, ItemClass.ItemPrefabOrder itemName)
    {
        Destroy(item);
        for(int j = 0; j < saveData.itemList.Count; j++)
        {
            if(saveData.itemList[j].prefabOrder == (int)itemName)
            {
                saveData.itemList.RemoveAt(j);
                data.Save();
                break;
            }
        }
    }


    //B3InventoryMng에서 옮겨온 애
     //실험대 켜지면 인벤토리 슬롯들 버튼 제어하기
    public void SetInvenSlotBtn_LT()
    {
        for(int i = 0; i < inventoryMng.slotList.Count; i++)
        {
            int index=i;
            if(inventoryMng.slotList[i].transform.childCount> 0 &&
                inventoryMng.slotList[i].transform.GetChild(0).tag != "Material")
            {
                inventoryMng.slotList[i].transform.GetChild(0).gameObject.
                GetComponent<Button>().enabled = false;
                inventoryMng.slotList[i].AddComponent<Button>();
                Button slotBtn = inventoryMng.slotList[i].GetComponent<Button>();
                slotBtn.onClick.AddListener(delegate{SlotFunction_LT(index);} );
            }
        }
    }
    public void  SlotFunction_LT(int i)
    {
        Debug.Log("Not material");
        uiManager.wrongMaterialUI.SetActive(true);  
        StartCoroutine(uiManager.LoadTextOneByOne(uiManager.wrongMaterialText.text, uiManager.inputTextUI));   
    }
    public void RevertInvenSlotBtn_LT()
    {
        for(int i = 0; i < inventoryMng.slotList.Count; i++)
        {
            if(inventoryMng.slotList[i].transform.childCount> 0)
            {
                inventoryMng.slotList[i].transform.GetChild(0).gameObject.
                GetComponent<Button>().enabled = true;
            }
            Destroy(inventoryMng.slotList[i].GetComponent<Button>());
        }
    }

}
