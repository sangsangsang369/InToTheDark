using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBtn : MonoBehaviour
{
    B5_UIManager uiManager;
    public MonsterBro monsterBro;
    
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        monsterBro  = FindObjectOfType<MonsterBro>();
    }

   

    public void Clicked()
    {
        monsterBro.monsterBroTrigger = true;
        uiManager.optionTool.gameObject.SetActive(false);
    }
}
