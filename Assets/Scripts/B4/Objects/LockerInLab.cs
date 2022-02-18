using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerInLab : Object
{
    [SerializeField] private GameObject researchRecord;

    public override void ObjectFunction()
    {
        researchRecord.SetActive(true);
    }
}
