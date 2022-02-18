using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B3InventoryMng : MonoBehaviour
{
    public List<GameObject> inventoryList;
    [HideInInspector] public List<GameObject> slotList;
    public List<bool> filledCheck;
    B3UIManager uiManager;

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
        uiManager = FindObjectOfType<B3UIManager>();
    }
    //게임씬에서 아이템 줍는 함수
    public void PickUp(GameObject item)
    {
        for(int i = 0; i < slotList.Count; i++)
        {
            if(!filledCheck[i])
            {
                filledCheck[i] = true;
                item.GetComponent<SpriteRenderer>().enabled = false; //sprite 꺼줘야
                item.GetComponent<Image>().enabled = true;
                item.transform.SetParent(slotList[i].transform);

                RectTransform itemRT = item.GetComponent<RectTransform>();
                itemRT.anchoredPosition = new Vector2(0, 0);
                itemRT.localScale = new Vector3(0.4f, 0.4f, 1f);
    
                break;
            }
        }
    }
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
    //자동으로 인벤토리에 들어오게 하는 함수
    public void AutoPickUp(GameObject collecteditem)
    {
        for(int i = 0; i < slotList.Count; i++)
        {
            if(!filledCheck[i])
            {
                filledCheck[i] = true;
                GameObject item = Instantiate(collecteditem, slotList[i].transform); //아이템 프리펩 생성

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

    //실험대 켜지면 인벤토리 슬롯들 버튼 제어하기
    public void SetInvenSlotBtn_LT()
    {
        for(int i = 0; i < slotList.Count; i++)
        {
            int index=i;
            if(slotList[i].transform.childCount> 0 &&
                slotList[i].transform.GetChild(0).tag != "Material")
            {
                slotList[i].transform.GetChild(0).gameObject.
                GetComponent<Button>().enabled = false;
                slotList[i].AddComponent<Button>();
                Button slotBtn = slotList[i].GetComponent<Button>();
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
        for(int i = 0; i < slotList.Count; i++)
        {
            if(slotList[i].transform.childCount> 0)
            {
                slotList[i].transform.GetChild(0).gameObject.
                GetComponent<Button>().enabled = true;
            }
            Destroy(slotList[i].GetComponent<Button>());
        }
    }
}
