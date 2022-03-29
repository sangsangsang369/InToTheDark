using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : Object
{
    public UI uiManager;
    public InventoryMng inventoryMng;
    //public Cabinet3 clockcabinet;
    public GameObject clockPanel;
    public GameObject prefabUI;
    public AnsCheck ansCheck;
    SlotSelectionMng slotSelectMng;
    SoundManager SM;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UI>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        
        ansCheck = FindObjectOfType<AnsCheck>();
        SM = SoundManager.inst;
    }

    // Update is called once per frame
    public void UseClock()
    {
        if (prefabUI.transform.parent == this.transform)
        {
            prefabUI.transform.SetParent(this.transform.parent.parent.parent.parent, false);
        }
        if (slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "회중시계";
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            SM.pocketwatchEffectPlay();
            clockPanel.SetActive(true); 
        }
    }

}
