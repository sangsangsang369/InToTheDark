using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureOnDoorAnim : MonoBehaviour
{
    bool plus = true;
    void Update()
    {
        if(plus)
        {
            this.transform.localScale += new Vector3(0.00005f,0.00005f,0);
            if(this.transform.localScale.x > 1.04f)
            {
                plus = false;
            }
        }
        else
        {
            this.transform.localScale -= new Vector3(0.0001f,0.0001f,0);
            if(this.transform.localScale.x < 1.02f)
            {
                plus = true;
            }
        }
        
    }
}
