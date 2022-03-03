using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorToB3 : Object
{
    public B2_UIManager uiManager;
    public InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;
    Sword1 sword1;
    Sword2 sword2;
    public bool isDoorOpened = false;

    public GameObject s1, s2;
    public bool s1On, s2On;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        sword1 = FindObjectOfType<Sword1>();
        sword2 = FindObjectOfType<Sword2>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (!isDoorOpened)
        {
            if (slotSelectMng.usableItem == "sword1Selected")
            {
                s1.SetActive(true);
            }
            if (slotSelectMng.usableItem == "sword2Selected")
            {
                s2.SetActive(true);
            }
            if (s1On && s2On)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        GetComponent<Animator>().SetTrigger("GoDown");

                    }
                
            }
        }
        
    }
}
