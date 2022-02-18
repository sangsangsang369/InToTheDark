using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B3ItemManager : MonoBehaviour
{
    public Sprite mufflerItemImg, letterItemImg, cardkeyItemImg, noteItemImg, fruitItemImg, branchItemImg, treesapItemImg, leafItemImg;
    public List<GameObject> inventoryList;
    public List<GameObject> slotList;
    public List<bool> filledCheck;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            slotList.Add(inventoryList[0].transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < slotList.Count; i++)
        {
            filledCheck.Add(false);
        }
    }

    public GameObject CheckSlot(Sprite itemImage)
    {
        Debug.Log("checkSlot");
        for (int i = 0; i < slotList.Count; i++)
        {
            if (!filledCheck[i])
            {
                filledCheck[i] = true;
                slotList[i].transform.GetChild(0).GetComponent<Image>().sprite = itemImage;
                slotList[i].transform.GetChild(0).gameObject.SetActive(true);
                return slotList[i].transform.GetChild(0).gameObject;
            }
        }
        return null;
    }
    public GameObject CheckSlot(Sprite itemImage,string itemTag)
    {
        Debug.Log("checkSlot");
        for (int i = 0; i < slotList.Count; i++)
        {
            if (!filledCheck[i])
            {
                filledCheck[i] = true;
                slotList[i].transform.GetChild(0).GetComponent<Image>().sprite = itemImage;
                slotList[i].transform.GetChild(0).gameObject.SetActive(true);
                slotList[i].transform.GetChild(0).tag = itemTag;
                return slotList[i].transform.GetChild(0).gameObject;
            }
        }
        return null;
    }

    //인벤에서 아이템 삭제
    public void RemoveSlot(string itemTag)
    {
        for(int i=0; i<slotList.Count; i++)
        {
            if (slotList[i].transform.GetChild(0).tag == itemTag)
            {
                slotList[i].transform.GetChild(0).gameObject.SetActive(false);
                filledCheck[i] = false;
            }
        }
    }

    //인벤에서 아이템 잠시 숨기기
    public void HideSlot(string itemTag)
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].transform.GetChild(0).tag == itemTag)
            {
                slotList[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    //인벤에서 숨긴 아이템 다시 표시하기
    public void ShowHideSlot(string itemTag)
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].transform.GetChild(0).tag == itemTag)
            {
                slotList[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    //인벤에서 숨겼던 아이템들 전부 한꺼번에 켜주기
    public void ShowAllHideSlot()
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            {
                if (filledCheck[i])
                {
                    slotList[i].transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
    }
}

