using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoMemoBtn : MonoBehaviour
{
    public GameObject pianoMemoUI;
    public void PianoMemoClick()
    {
        pianoMemoUI.SetActive(true);   
    }
}
