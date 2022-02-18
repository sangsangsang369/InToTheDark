using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : Object
{
    public GameObject priestUI;
    public Text priestText;
    public Text inputTextUI;
    B5_UIManager uiManager;
    Player player;
    public GameObject walls;
    public GameObject globalLight;
    

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    public override void ObjectFunction()
    {
        player.currRoom = "Estrade";
        //globalLight.GetComponent<Animator>().SetBool("LightOff", true);
        walls.GetComponent<Animator>().SetTrigger("Open");
        //globalLight.GetComponent<Animator>().SetBool("LightOff", false);


        //priestUI.SetActive(true);
        //StartCoroutine(uiManager.LoadTextOneByOne(priestText.text, inputTextUI));
    }
}
