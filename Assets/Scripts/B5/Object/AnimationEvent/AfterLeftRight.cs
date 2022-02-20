using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterLeftRight : MonoBehaviour
{
    public GameObject monsterBro;
    public GameObject fadeOut;
    bool monsterBroTrigger = false;

    private void Update() 
    {
        MonsterBroWalking_Two();
    }

    public void MonsterBroWalkTrigger()
    {
        monsterBroTrigger = true;
    }
    private void MonsterBroWalking_Two()
    {
        if (monsterBroTrigger && monsterBro.transform.position.x < 28)
        {
            monsterBro.GetComponent<Animator>().SetBool("isWalking", true);
            monsterBro.transform.position += Vector3.right * 1f * Time.deltaTime;
            fadeOut.SetActive(true);
            fadeOut.GetComponent<Animator>().SetBool("fadeOut", true);
        }
    }
}
