using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B2_Frame2 : Object
{
    public B2_UIManager uiManager;
    public GameObject frame2UI;
    public Text frame2Text;
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
        frame2UI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(frame2Text.text, inputTextUI));
    }
}

