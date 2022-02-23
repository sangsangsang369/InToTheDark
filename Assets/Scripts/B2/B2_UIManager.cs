using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class B2_UIManager : UI
{
    InventoryMng inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryMng>();
    }
}
