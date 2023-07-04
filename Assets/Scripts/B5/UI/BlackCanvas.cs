using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCanvas : MonoBehaviour
{
    private float time_current = 3f;
    private bool isEnded;
    public GameObject NewsCanvas;

    void Update()
    {
        if (0 < time_current)
        {
            time_current -= Time.deltaTime;
            if(0 >= time_current)
            {
                NewsCanvas.SetActive(true);
                //this.gameObject.SetActive(false);
                return;
            }
        }
    }   
    
}
