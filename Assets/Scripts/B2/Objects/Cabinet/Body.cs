using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Body : Object
{
    public B2_UIManager uiManager;
    public GameObject bodyUI;
    public Text bodyText;
    public Text inputTextUI;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<B2_UIManager>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bodyUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(bodyText.text, inputTextUI));
        }
    }              
}
