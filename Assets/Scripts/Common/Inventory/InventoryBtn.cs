using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBtn : MonoBehaviour
{
    InventoryMng inventoryMng;
    SoundManager inst;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMng = FindObjectOfType<InventoryMng>();
        inst = SoundManager.inst;
        int totalInventoryPage = inventoryMng.inventoryList.Count % 6 + 1;
        if(inventoryMng.currentPage == totalInventoryPage && inventoryMng.currentPage == 1){
            this.GetComponent<Button>().interactable = false;
            Debug.Log("btn disabled");
        }
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
                inst.itemSource.clip = inst.buttonEffect;
                inst.itemSource.Play();
            }
        }
        else
        {
            if(currentPage != inventoryMng.inventoryList.Count)
            {
                inventoryMng.inventoryList[currentPage - 1].SetActive(false);
                inventoryMng.inventoryList[currentPage].SetActive(true);
                inventoryMng.currentPage++;
                inst.itemSource.clip = inst.buttonEffect;
                inst.itemSource.Play();
            }
        }
    }
}
