using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBtn : MonoBehaviour
{
    InventoryMng inventoryMng;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMng = FindObjectOfType<InventoryMng>();
    }

    public void TurnPage(bool isLeftBtn)
    {
        int currentPage = inventoryMng.currentPage;
        if(isLeftBtn)
        {
            if(currentPage != 1)
            {
                inventoryMng.inventoryList[currentPage - 1].SetActive(false);
                inventoryMng.inventoryList[currentPage - 2].SetActive(true);
                inventoryMng.currentPage--;
            }
        }
        else
        {
            if(currentPage != inventoryMng.inventoryList.Count)
            {
                inventoryMng.inventoryList[currentPage - 1].SetActive(false);
                inventoryMng.inventoryList[currentPage].SetActive(true);
                inventoryMng.currentPage++;
            }
        }
    }
}
