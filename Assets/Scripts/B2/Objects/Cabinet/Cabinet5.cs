using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabinet5 : Object
{
    public B2_UIManager uiManager;
    public GameObject cabinet5UI;
    public List<Text> cabinet5Texts;
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
        cabinet5UI.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(uiManager.LoadTexts(cabinet5Texts, inputTextUI, 2));
        }
    }
}
