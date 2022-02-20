using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : CollisionObject
{
    public GameObject priest, priestUI;
    public List<Text> priestTexts;
    public Text inputTextUI;
    B5_UIManager uiManager;
    Player player;
    public GameObject walls;
    public GameObject floor;
    public GameObject globalLight;
    public int scptOn = 0;
    public bool priestWalk = false;
    

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        player = FindObjectOfType<Player>();
    }
    void Update() {
        if(priestWalk)
        {
            if(priest.transform.position.x > 35)
            {
                priest.GetComponent<Animator>().SetBool("WalkOn", true);
                priest.transform.position += Vector3.left * 5 * Time.deltaTime;
            }  
        }
        if(!priestUI.activeSelf&& scptOn == 1)
        {
            priest.GetComponent<Animator>().SetBool("HandsUp", true);
            scptOn++;
        }
    }

    public override void CollisionObjectFunction()
    {
        player.currRoom = "Estrade";
        globalLight.GetComponent<Animator>().SetBool("LightOff", true);
        floor.SetActive(false);
        walls.GetComponent<Animator>().SetTrigger("Open");
        priestWalk = true;
        if(scptOn == 0)
        {
            Invoke("OnScript", 2.5f);
        }
    }

    void OnScript()
    {
        priestUI.SetActive(true);
        uiManager.StartCoroutine(uiManager.LoadTexts(priestTexts, inputTextUI, 10));
        scptOn++; 
    }
}
