using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveAlarm : MonoBehaviour
{   
    [SerializeField] private Text alarmText;

    public void SaveAlarmPopUp()
    {   
        alarmText.gameObject.SetActive(true);
        alarmText.gameObject.GetComponent<Animator>().SetBool("fade", true);
    }

    public void fadeOut()
    {
        alarmText.gameObject.SetActive(false);
        alarmText.gameObject.GetComponent<Animator>().SetBool("fade", false);
    }
}
