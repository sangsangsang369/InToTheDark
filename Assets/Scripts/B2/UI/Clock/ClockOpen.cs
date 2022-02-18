using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockOpen : MonoBehaviour
{
    //public GameObject MainClock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OpenClock()
    {
        GameObject MainClock = GameObject.Find("ClockPanel");
        if (MainClock)
        {
            MainClock.gameObject.SetActive(true);
        }
        else
            Debug.Log("뭐임?");
        
    }
}
