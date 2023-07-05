using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBlack : MonoBehaviour
{
    public GameObject newsScene1;
    
    public void SetOnNewsPanel(){
        newsScene1.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
