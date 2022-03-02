using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerWithLock : Object
{
    DataManager data;
    SaveDataClass saveData;

    public bool isB4LockUnlocked;
    [SerializeField] private GameObject lockImage;
    [SerializeField] private GameObject lockObj;
    [SerializeField] private GameObject researchRecord;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        isB4LockUnlocked = saveData.isB4LockUnlocked;
        if(isB4LockUnlocked)
        {
            lockImage.SetActive(false);
        }
    }

    public override void ObjectFunction()
    {
        if(!isB4LockUnlocked)
        {
            lockObj.SetActive(true);
        }
        else
        {
            researchRecord.SetActive(true);
        }
    }
}
