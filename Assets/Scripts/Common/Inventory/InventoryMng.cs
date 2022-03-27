using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMng : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;

    public int currentPage = 1;
    public List<GameObject> inventoryList;
    public List<GameObject> slotList;
    public List<bool> filledCheck;
    [SerializeField] private GameObject inventoryPrefab;
    [SerializeField] private GameObject inventoryParent;
    [SerializeField] private Sprite unselectedSlot;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        
        //아이템의 갯수가 0이나 6의 배수가 아니면
        if(saveData.itemList.Count % 6 != 0)
        {
            for(int i = 0; i < (int)(saveData.itemList.Count / 6) + 1; i++)
            {
                if(i == 0)
                {
                    AddNewInventory(true);
                }
                else
                {
                    AddNewInventory(false);
                }
            }
        }
        //아이템의 갯수가 0이나 6의 배수라면
        else 
        {
            //아이템의 갯수가 6보다 크거나 같다면
            if((int)(saveData.itemList.Count / 6) != 0)
            {
                for(int i = 0; i < (int)(saveData.itemList.Count / 6); i++)
                {
                    if(i == 0)
                    {
                        AddNewInventory(true);
                    }
                    else
                    {
                        AddNewInventory(false);
                    }
                }
            }
            //아이템의 갯수가 6보다 작다면
            else
            {
                AddNewInventory(true);
            }
        }

        for(int i = 0; i < saveData.itemList.Count; i++)
        {
            int itemIndex = saveData.itemList[i].prefabOrder;
            if(itemIndex <= 3 || itemIndex == 18)
            {
                InstantiateItemsOnInventory(data.itemPrefabs[itemIndex].gameObject, 0.1f);
            }
            else if(itemIndex == 19)
            {
                InstantiateItemsOnInventory(data.itemPrefabs[itemIndex].gameObject, 0.2f);
            }
            else if(itemIndex > 3 && itemIndex <= 7)
            {
                InstantiateItemsOnInventory(data.itemPrefabs[itemIndex].gameObject, 1f);
            }
            else
            {
                InstantiateItemsOnInventory(data.itemPrefabs[itemIndex].gameObject, 0.4f);
            }
        }
    }

    private void InstantiateItemsOnInventory(GameObject item, float size)
    {
        for(int i = 0; i < slotList.Count; i++)
        {
            if(!filledCheck[i])
            {
                filledCheck[i] = true;
                if(item.GetComponent<SpriteRenderer>())
                {
                    item.GetComponent<SpriteRenderer>().enabled = false;
                }
                item.GetComponent<Image>().enabled = true;
                GameObject item_n = Instantiate(item, slotList[i].transform);
                RectTransform itemRT = item_n.GetComponent<RectTransform>();
                itemRT.anchoredPosition = new Vector2(0, 0);
                itemRT.localScale = new Vector3(size, size, size);
    
                break;
            }
            else if(filledCheck[slotList.Count - 1])
            {
                AddNewInventory(false);
            }
        }
    }

    public void PickUp(GameObject item, float size, ItemClass.ItemPrefabOrder order) //월드에 있는 아이템 줍기
    {
        for(int i = 0; i < slotList.Count; i++)
        {
            if(!filledCheck[i])
            {
                filledCheck[i] = true;
                if(item.GetComponent<SpriteRenderer>())
                {
                    item.GetComponent<SpriteRenderer>().enabled = false;
                }
                item.GetComponent<Image>().enabled = true;
                RectTransform itemRT = item.GetComponent<RectTransform>();
                item.transform.SetParent(slotList[i].transform);
                itemRT.anchoredPosition = new Vector2(0, 0);
                itemRT.localScale = new Vector3(size, size, 1f);
    
                break;
            }
            else if(filledCheck[slotList.Count - 1])
            {
                AddNewInventory(false);
            }
        }
        ItemClass itemPicked = new ItemClass(order);
        saveData.itemList.Add(itemPicked);
        data.Save();
    }

    public void AddToInventory(GameObject item, float size, ItemClass.ItemPrefabOrder order) //월드에 없는 아이템 줍기
    {
        for(int i = 0; i < slotList.Count; i++)
        {
            if(!filledCheck[i])
            {
                filledCheck[i] = true;
                GameObject item_n = Instantiate(item, slotList[i].transform);
                RectTransform itemRT = item_n.GetComponent<RectTransform>();
                itemRT.anchoredPosition = new Vector2(0, 0);
                itemRT.localScale = new Vector3(size, size, size);
    
                break;
            }
            else if(filledCheck[slotList.Count - 1])
            {
                AddNewInventory(false);
            }
        }
        ItemClass itemPicked = new ItemClass(order);
        saveData.itemList.Add(itemPicked);
        data.Save();
    }

    private void AddNewInventory(bool OnOff) // 새로운 인벤토리창 추가
    {
        GameObject addedInventory = Instantiate(inventoryPrefab, inventoryParent.transform);
        addedInventory.SetActive(OnOff);
        inventoryList.Add(addedInventory);
        for(int j = 0; j < 6; j++)
        {
            slotList.Add(addedInventory.transform.GetChild(j).gameObject);
            filledCheck.Add(false);
        }
    }

    // slotSelectMng.SelectionClear();
    // Remove함수와 항상 같이 사용
    public void RemoveFromInventory(GameObject item, ItemClass.ItemPrefabOrder itemName) // 아이템 사용 후 없어지는 경우
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
        if(!filledCheck[slotList.Count - 6] && slotList.Count > 6)
        {
            inventoryList.RemoveAt(inventoryList.Count - 1);
            if(currentPage == 2)
            {
                currentPage--;
            }
            Destroy(slotList[slotList.Count - 6].transform.parent.gameObject);
            inventoryList[0].gameObject.SetActive(true);
            slotList.RemoveRange(6, 6);
        }

        //세이브 데이터의 아이템리스트에서도 제거
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

    //위의 함수에서 정리하는 부분만 떼서 함수 만들었습니다
    public void OrganizeInventory() // 인벤토리 빈칸 없애는 기능
    {
        for(int i = 0; i < slotList.Count - 1; i++)
        {
            for (int j = 1; j < slotList.Count - i; j++)
            {
                if(slotList[i].transform.childCount != 0)
                {
                    break;
                }
                else if(slotList[i].transform.childCount == 0 && slotList[i + j].transform.childCount == 0)
                {
                    continue;
                }
                else if(slotList[i].transform.childCount == 0 && slotList[i + j].transform.childCount != 0)
                {
                    slotList[i + j].transform.GetChild(0).SetParent(slotList[i].transform);
                    slotList[i].transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
                    break;
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
        if(!filledCheck[slotList.Count - 6] && slotList.Count > 6)
        {
            inventoryList.RemoveAt(inventoryList.Count - 1);
            if(currentPage == 2)
            {
                currentPage--;
            }
            Destroy(slotList[slotList.Count - 6].transform.parent.gameObject);
            inventoryList[0].gameObject.SetActive(true);
            slotList.RemoveRange(6, 6);
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
