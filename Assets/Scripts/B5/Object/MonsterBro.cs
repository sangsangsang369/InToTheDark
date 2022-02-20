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
        MonsterBroWalking(28.7f);
        AfterMonsterBroWalking();
    }
    private void MonsterBroWalking(float limit)
    {    
        if(this.gameObject.activeSelf == true)
            if (player.transform.position.x < limit)
            {
                this.gameObject.GetComponent<Animator>().SetBool("isWalking", true);
                player.GetComponent<Animator>().SetFloat("flip", -1);
                player.GetComponent<Animator>().SetBool("isWalking", true);

                if(player.transform.position.x <= 21)
                {
                    this.gameObject.transform.position += Vector3.right * 1.1f * Time.deltaTime;
                    player.transform.position += Vector3.right * 0.4f * Time.deltaTime;
                }
                else if(player.transform.position.x <= 24 && player.transform.position.x > 21)
                {
                    this.gameObject.transform.position += Vector3.right * 1.4f * Time.deltaTime;
                    player.transform.position += Vector3.right * 1f * Time.deltaTime;
                }
                else if(player.transform.position.x > 24)
                {
                    this.gameObject.transform.position += Vector3.right * 1.3f * Time.deltaTime;
                    player.transform.position += Vector3.right * 1.3f * Time.deltaTime;
                }
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
