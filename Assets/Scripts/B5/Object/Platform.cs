using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : Object
{
    public GameObject priest, priestUI;
    public List<Text> priestTexts;
    public Text inputTextUI;
    B5_UIManager uiManager;
    Player player;
    public GameObject walls;
    public GameObject globalLight;
    public bool scptOn = true;
    

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
        globalLight.GetComponent<Animator>().SetBool("LightOff", true);
        walls.GetComponent<Animator>().SetTrigger("Open");
        priest.GetComponent<Animator>().SetBool("WalkOn", true);
        Invoke("OnScript", 80.5f);
        if (!scptOn)
        {
            priest.GetComponent<Animator>().SetBool("HandsUp", true);
        }
    }

    void OnScript()
    {
        priestUI.SetActive(true);
        //scptOn = true;
        uiManager.StartCoroutine(uiManager.LoadTexts(priestTexts, inputTextUI, 10));
        priestUI.SetActive(false);
        scptOn = false;
    }
}
