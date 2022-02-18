using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedJewel : MonoBehaviour
{
    [HideInInspector] public bool isJewelOnHand = false;
    [SerializeField] private Sprite slotSelected;
    [SerializeField] private Sprite slotUnselected;

    public void RedJewelItem()
    {   
        GameObject jewelSlot = this.transform.parent.gameObject;
        if(!isJewelOnHand)
        {
            jewelSlot.GetComponent<Image>().sprite = slotSelected;
            isJewelOnHand = true;
        }
        else
        {
            jewelSlot.GetComponent<Image>().sprite = slotUnselected;
            isJewelOnHand = false;
        }
    }
}
