using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabinet2 : Object
{
    public B2_UIManager uiManager;
    public InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;
    public GameObject cabinet2UI, sword1UI, sword1Img;
    public Text cabinet2Text, sword1Text;
    public Text inputTextUI;
    Player player;
    Key key;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                key = FindObjectOfType<Key>();
                if (key && slotSelectMng.usableItem == "keySelected")
                {
                    sword1UI.SetActive(true);
                    StartCoroutine(uiManager.LoadTextOneByOne(sword1Text.text, inputTextUI));
                    GameObject sword1 = sword1Img;
                    inventoryMng.AddToInventory(sword1, 1f, ItemClass.ItemPrefabOrder.Sword1);
                }
                else
                {
                    cabinet2UI.SetActive(true);
                    StartCoroutine(uiManager.LoadTextOneByOne(cabinet2Text.text, inputTextUI));
                }
            } 
    }
}
