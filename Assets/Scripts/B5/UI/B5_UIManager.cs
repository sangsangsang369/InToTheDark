using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class B5_UIManager : UI
{
    public OptionTool optionTool;
    public MonsterBro monsterBro;

    // Start is called before the first frame update
    void Start()
    {
        //optionTool = FindObjectOfType<OptionTool>();
        //monsterBro = FindObjectOfType<MonsterBro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Option() 
    {
        if(optionTool.haveMuf || optionTool.haveKnife)
        {
            optionTool.OptionPanelOn();
        }
        else
        {
            monsterBro.monsterBroTextNum++;
        }   
    }
}

