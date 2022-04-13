using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterEndingCreditUp : MonoBehaviour
{
    public GameObject creditBGBtn; 

    SceneLoadManager sceneLoader;

    private void Start()
    {
        sceneLoader = SceneLoadManager.instance;
        creditBGBtn.GetComponent<Button>().enabled = false;
    }

    public void BtnActivate()
    {
        creditBGBtn.GetComponent<Button>().enabled = true;
    }

    public void GoToMainScene()
    {
        sceneLoader.LoadScene("Start");
        creditBGBtn.GetComponent<Button>().enabled = false;
    }
}
