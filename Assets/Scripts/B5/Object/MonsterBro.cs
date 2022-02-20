using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBro : MonoBehaviour
{
    public GameObject player;
    public GameObject monsterBroObj;
    B5_UIManager uiManager;
    public GameObject monsterBroUI;
    public GameObject fadeOut;
    public Text monsterBroText;
    public Text inputTextUI;
    int monsterBroTextNum = 0;
    public int leftRight =0;

    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
    }
    void Update()
    {
        MonsterBroWalking(21.5f);
        AfterMonsterBroWalking();
        GetMonsterWalk();
    }
    private void MonsterBroWalking(float limit)
    {    
        if(this.gameObject.activeSelf == true)
            if (this.gameObject.transform.position.x < limit)
            {
                this.gameObject.GetComponent<Animator>().SetBool("isWalking", true);
                this.gameObject.transform.position += Vector3.right * 2.5f * Time.deltaTime;
                player.GetComponent<Animator>().SetBool("isWalking", true);
                player.transform.position += Vector3.right * 1.8f * Time.deltaTime;
            }
            else if(monsterBroTextNum ==0)
            {
                this.gameObject.GetComponent<Animator>().SetBool("isWalking", false);
                player.GetComponent<Animator>().SetBool("isWalking", false);

                monsterBroUI.SetActive(true);
                uiManager.StartCoroutine(uiManager.LoadTextOneByOne(monsterBroText.text, inputTextUI));
                monsterBroTextNum++;
            }
    }

    private void AfterMonsterBroWalking()
    {
        if(monsterBroUI.activeSelf==false && monsterBroTextNum == 1)        
        {
            player.GetComponent<Animator>().SetBool("leftRight", true);
            leftRight=1;
        }
    }
    private void MonsterBroWalkingTwo()
    {
        if (this.gameObject.transform.position.x < 28)
        {
            this.gameObject.GetComponent<Animator>().SetBool("isWalking", true);
            this.gameObject.transform.position += Vector3.right * 1.1f * Time.deltaTime;
            fadeOut.SetActive(true);
            fadeOut.GetComponent<Animator>().SetBool("fadeOut", true);
        }
    }

    public void GetMonsterWalk()
    {
        if(leftRight==1)
        {
            Invoke("MonsterBroWalkingTwo",2.5f);
        }
    }
}
