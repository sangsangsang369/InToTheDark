using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCanvas : MonoBehaviour
{
    public GameObject EndingAnim;

    public void EndingAnimOn()
    {
        EndingAnim.SetActive(true);
        this.gameObject.SetActive(false);
    } 
    
}
