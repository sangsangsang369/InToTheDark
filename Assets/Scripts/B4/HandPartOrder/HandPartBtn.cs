using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandPartBtn : MonoBehaviour
{
    PartOrderMng partOrderMng;
    string partName;

    // Start is called before the first frame update
    void Start()
    {
        partOrderMng = FindObjectOfType<PartOrderMng>();
        partName = this.gameObject.name;
    }

    public void PartBtn()
    {
        if(partOrderMng.answerSheet.Count < 6)
        {
            partOrderMng.answerSheet.Add(partName);
            if(partOrderMng.answerSheet.Count == 6)
            {
                partOrderMng.CheckOrder();
            }
        }
    }
}
