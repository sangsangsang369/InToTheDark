using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public void GoldColor(Text text){
        text.GetComponent<Text>().color = new Color(200, 188, 145, 255);
    }
}
