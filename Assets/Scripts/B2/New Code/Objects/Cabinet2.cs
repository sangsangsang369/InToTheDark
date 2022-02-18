using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabinet2 : Object
{
    public B2_UIManager uiManager;
    public B2_InventoryManager inventoryMng;
    public GameObject cabinet2UI, sword1UI, sword1Img;
    public Text cabinet2Text, sword1Text;
    public Text inputTextUI;
    Player player;
    bool key1Picked = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<B2_InventoryManager>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (key1Picked)
                {
                    sword1UI.SetActive(true);
                    StartCoroutine(uiManager.LoadTextOneByOne(sword1Text.text, inputTextUI));
                    GameObject sword1 = sword1Img;
                    inventoryMng.AddToInventory(sword1);
                }
                else
                {
                    cabinet2UI.SetActive(true);
                    StartCoroutine(uiManager.LoadTextOneByOne(cabinet2Text.text, inputTextUI));
                }
            } 
    }
}
