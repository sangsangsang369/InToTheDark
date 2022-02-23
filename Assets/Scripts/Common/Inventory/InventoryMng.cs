using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMng : MonoBehaviour
{
    [HideInInspector] public int currentPage = 1;
    public List<GameObject> inventoryList;
    [HideInInspector] public List<GameObject> slotList;
    [HideInInspector] public List<bool> filledCheck;
    [SerializeField] private GameObject inventoryPrefab;
    [SerializeField] private GameObject inventoryParent;
    [SerializeField] private Sprite unselectedSlot;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < inventoryList.Count; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                slotList.Add(inventoryList[i].transform.GetChild(j).gameObject);
            }
        }
        for(int i = 0; i < slotList.Count; i++)
        {
            filledCheck.Add(false);
        }
    }

    public void PickUp(GameObject item) //월드에 있는 아이템 줍기
    {
        for(int i = 0; i < slotList.Count; i++)
        {
            if(!filledCheck[i])
            {
                filledCheck[i] = true;
                item.GetComponent<SpriteRenderer>().enabled = false;
                item.GetComponent<Image>().enabled = true;
                RectTransform itemRT = item.GetComponent<RectTransform>();
                item.transform.SetParent(slotList[i].transform);
                itemRT.anchoredPosition = new Vector2(0, 0);
                itemRT.localScale = new Vector3(0.1f, 0.1f, 1f);
    
                break;
            }
            else if(filledCheck[slotList.Count - 1])
            {
                AddNewInventory();
            }
        }
    }

    public void AddToInventory(GameObject item) //월드에 없는 아이템 줍기
    {
        for(int i = 0; i < slotList.Count; i++)
        {
            if(!filledCheck[i])
            {
                filledCheck[i] = true;
                GameObject item_n = Instantiate(item, slotList[i].transform);
                RectTransform itemRT = item_n.GetComponent<RectTransform>();
                itemRT.anchoredPosition = new Vector2(0, 0);
                itemRT.localScale = new Vector3(0.1f, 0.1f, 1f);
    
                break;
            }
            else if(filledCheck[slotList.Count - 1])
            {
                AddNewInventory();
            }
        }
    }

    private void AddNewInventory() // 새로운 인벤토리창 추가
    {
        GameObject addedInventory = Instantiate(inventoryPrefab, inventoryParent.transform);
        addedInventory.SetActive(false);
        inventoryList.Add(addedInventory);
        for(int j = 0; j < 6; j++)
        {
            slotList.Add(addedInventory.transform.GetChild(j).gameObject);
            filledCheck.Add(false);
        }
    }

    // slotSelectMng.SelectionClear();
    // Remove함수와 항상 같이 사용
    public void RemoveFromInventory(GameObject item) // 아이템 사용 후 없어지는 경우
    {
        item.transform.parent.GetComponent<Image>().sprite = unselectedSlot;
        item.transform.parent.DetachChildren();
        Destroy(item);
        //인벤토리 정렬
        for(int i = 0; i < slotList.Count - 1; i++)
        {
            if(slotList[i + 1].transform.childCount != 0)
            {
                if(slotList[i].transform.childCount == 0 && slotList[i + 1].transform.childCount != 0)
                {
                    slotList[i + 1].transform.GetChild(0).SetParent(slotList[i].transform);
                    slotList[i].transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
                }
            } 
        }
        for(int i = 0; i < slotList.Count; i++) 
        {
            if(slotList[i].transform.childCount != 0)
            {
                filledCheck[i] = true;
            }
            else
            {
                filledCheck[i] = false;
            }
        }
        if(!filledCheck[slotList.Count - 6])
        {
            Destroy(slotList[slotList.Count - 6].transform.parent.gameObject);
        }
    }

    //위의 함수에서 정리하는 부분만 떼서 함수 만들었습니다
    public void OrganizeInventory() // 인벤토리 빈칸 없애는 기능
    {
        for(int i = 0; i < slotList.Count - 1; i++)
        {
            if(slotList[i + 1].transform.childCount != 0)
            {
                if(slotList[i].transform.childCount == 0 && slotList[i + 1].transform.childCount != 0)
                {
                    slotList[i + 1].transform.GetChild(0).SetParent(slotList[i].transform);
                    slotList[i].transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
                }
            }
        }
        for(int i = 0; i < slotList.Count; i++) 
        {
            if(slotList[i].transform.childCount != 0)
            {
                filledCheck[i] = true;
            }
            else
            {
                filledCheck[i] = false;
            }
        }
    }

    //B3InventoryMng에서 옮긴 함수(B3F에서만 사용)
    //실험대 슬롯에서 아이템 줍는 함수
    public void PickUpfromSlot(GameObject item)
    {
        for(int i = 0; i < slotList.Count; i++)
        {
            if(!filledCheck[i])
            {
                filledCheck[i] = true;
                item.transform.SetParent(slotList[i].transform);
                RectTransform itemRT = item.GetComponent<RectTransform>();
                itemRT.anchoredPosition = new Vector2(0, 0);
                itemRT.localScale = new Vector3(0.4f, 0.4f, 1f);
    
                break;
            }
        }
    }
  
    //슬롯에서 아이템 위치 찾아서 그 위치의 filledCheck false로 
    public void FilledChecktoFalse(GameObject item) 
    {
        for(int i= 0; i < slotList.Count; i++)
        {
            if(slotList[i].transform.childCount>0
            && slotList[i].transform.GetChild(0).gameObject == item) 
            {
                filledCheck[i] = false;
                break;
            }
        }
    }   
}
