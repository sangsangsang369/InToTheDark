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

    public void PickUp(GameObject item)
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

    public void AddToInventory(GameObject item)
    {
        for(int i = 0; i < slotList.Count; i++)
        {
            if(!filledCheck[i])
            {
                filledCheck[i] = true;
                Instantiate(item, slotList[i].transform);
                RectTransform itemRT = item.GetComponent<RectTransform>();
                itemRT.anchoredPosition = new Vector2(0, 0);
    
                break;
            }
            else if(filledCheck[slotList.Count - 1])
            {
                AddNewInventory();
            }
        }
    }

    private void AddNewInventory()
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

    public void RemoveFromInventory(GameObject item)
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
}
