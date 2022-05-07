using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockTip : Object
{
    public UI uiManager;
    public InventoryMng inventoryMng;
    [SerializeField] Clock clock;
    public GameObject clockTipUI;
    public List<Text> clockText;
    public Text inputTextUI;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B2_UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        clock = FindObjectOfType<Clock>();
    }

    // Update is called once per frame
        public override void ObjectFunction()
    {
        clockTipUI.SetActive(true);
        StartCoroutine(uiManager.LoadTexts(clockText, inputTextUI, 2));
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            clockTipUI.SetActive(false);
        }
    }
}
