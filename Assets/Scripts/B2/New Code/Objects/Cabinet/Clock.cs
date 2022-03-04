using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : Object
{
    public B2_UIManager uiManager;
    public InventoryMng inventoryMng;
    public Cabinet3 clockcabinet;
    public AnsCheck ansCheck;
    public ClockOpen clockOpen;
    SlotSelectionMng slotSelectMng;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        clockcabinet = FindObjectOfType<Cabinet3>();
        ansCheck = FindObjectOfType<AnsCheck>();
        clockOpen = FindObjectOfType<ClockOpen>();

    }

    // Update is called once per frame
    public void UseClock()
    {
        if (slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            clockcabinet.clockPanel.SetActive(true); 
        }
      
    }
}
