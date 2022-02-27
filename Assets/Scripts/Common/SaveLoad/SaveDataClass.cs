using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveDataClass
{
    public bool alreadyOpen;
    List<Object> objectList = new List<Object>();
    public SaveDataClass()
    {
        alreadyOpen = false;
    }
}
