using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B2_InventoryManager : MonoBehaviour
{
    public List<GameObject> inventoryList;
    [HideInInspector] public List<GameObject> slotList;
    [HideInInspector] public List<bool> filledCheck;
    B2_UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventoryList.Count; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                slotList.Add(inventoryList[i].transform.GetChild(j).gameObject);
            }
        }
        for (int i = 0; i < slotList.Count; i++)
        {
            filledCheck.Add(false);
        }
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    public void PickUp(GameObject item)
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if (!filledCheck[i])
            {
                filledCheck[i] = true;
                item.GetComponent<SpriteRenderer>().enabled = false;
                item.GetComponent<Image>().enabled = true;
                item.transform.SetParent(slotList[i].transform);
                RectTransform itemRT = item.GetComponent<RectTransform>();
                //item.transform.SetParent(slotList[i].transform);
                itemRT.anchoredPosition = new Vector2(0, 0);
                //itemRT.localScale = new Vector3(0.12f, 0.12f, 1f);

                break;
            }
        }
    }

    public void AddToInventory(GameObject item)
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if (!filledCheck[i])
            {
                filledCheck[i] = true;
                Instantiate(item, slotList[i].transform);
                RectTransform itemRT = item.GetComponent<RectTransform>();
                itemRT.anchoredPosition = new Vector2(0, 0);
                itemRT.localScale = new Vector3(0.12f, 0.12f, 1f);

                break;
            }
        }
    }
}
