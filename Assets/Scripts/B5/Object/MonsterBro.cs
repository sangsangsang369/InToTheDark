using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBro : MonoBehaviour
{
    public GameObject player;
    B5_UIManager uiManager;
    public GameObject monsterBroUI;
    public Text monsterBroText;
    public Text inputTextUI;
    int monsterBroTextNum = 0;

    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
    }
    void Update()
    {
        MonsterBroWalking(21.5f);
        AfterMonsterBroWalking();
    }
    private void MonsterBroWalking(float limit)
    {    
        if(this.gameObject.activeSelf == true)
            if (this.gameObject.transform.position.x < limit)
            {
                this.gameObject.GetComponent<Animator>().SetBool("isWalking", true);
                this.gameObject.transform.position += Vector3.right * 2.5f * Time.deltaTime;
                
                player.GetComponent<Animator>().SetFloat("flip", -1);
                player.GetComponent<Animator>().SetBool("isWalking", true);
                player.transform.position += Vector3.right * 2f * Time.deltaTime;
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
        }
    }
}
