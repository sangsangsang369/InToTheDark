using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cabinet4 : Object
{
    public B2_UIManager uiManager;
    public GameObject cabinet4UI;
    public Text cabinet4Text;
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
        cabinet4UI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(cabinet4Text.text, inputTextUI));
    }
}

