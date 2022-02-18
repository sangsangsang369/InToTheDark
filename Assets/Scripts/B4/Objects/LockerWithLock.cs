using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerWithLock : Object
{
    public bool isUnlocked = false;
    [SerializeField] private GameObject lockObj;
    [SerializeField] private GameObject researchRecord;

    public override void ObjectFunction()
    {
        if(!isUnlocked)
        {
            lockObj.SetActive(true);
        }
        else
        {
            researchRecord.SetActive(true);
        }
    }
}
