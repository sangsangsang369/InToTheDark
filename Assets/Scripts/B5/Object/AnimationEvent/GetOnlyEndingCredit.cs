using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOnlyEndingCredit : MonoBehaviour
{
    public GameObject endingCredit, endingCreditParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndingCreditOn()
    {
        endingCreditParent.SetActive(true);
        endingCredit.GetComponent<Animator>().SetTrigger("TheEnd");
    }
}
