using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cabinet3 : Object
{
    public B2_UIManager uiManager;
    public InventoryMng inventoryMng;
    public GameObject cabinet3UI, clockImg;
    public List<Text> cabinet3Texts;
    public Text inputTextUI;
    public bool alreadyOpen = false;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        cabinet3UI.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!alreadyOpen)
            {
                StartCoroutine(uiManager.LoadTexts(cabinet3Texts, inputTextUI, 3));
                GameObject clock = clockImg;
                inventoryMng.AddToInventory(clock);
                alreadyOpen = true;
            }
            else
            {
                Debug.Log("이미 얻은 물품입니다.");
            }
        }
    }
}
