using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B2_Frame4 : Object
{
    public B2_UIManager uiManager;
    public GameObject frame4UI;
    public List<Text> frame4Texts;
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
        frame4UI.SetActive(true);
        StartCoroutine(uiManager.LoadTexts(frame4Texts, inputTextUI, 2));
    }
}
