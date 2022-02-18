using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardKey : MonoBehaviour
{
    [HideInInspector] public bool isCardOnHand = false;
    [SerializeField] private Sprite slotSelected;
    [SerializeField] private Sprite slotUnselected;

    public void CardKeyItem()
    {   
        GameObject cardkeySlot = this.transform.parent.gameObject;
        if(!isCardOnHand)
        {
            cardkeySlot.GetComponent<Image>().sprite = slotSelected;
            isCardOnHand = true;
        }
        else
        {
            cardkeySlot.GetComponent<Image>().sprite = slotUnselected;
            isCardOnHand = false;
        }
    }
}
