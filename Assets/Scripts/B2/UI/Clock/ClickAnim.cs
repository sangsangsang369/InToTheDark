using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().SetBool("PressOn", false);
    }

    public void PressOn(){
        this.GetComponent<Animator>().SetBool("PressOn", true);
        Debug.Log("pressing");
    }

    public void PointerOut(){
        this.GetComponent<Animator>().SetBool("PressOn", false);
    }
}
