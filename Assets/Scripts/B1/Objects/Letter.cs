using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : Object
{
    public GameObject letterUI;
    UI uiManager;
    InventoryMng inventoryMng;
    SlotSelectionMng slotSelectMng;

    DataManager data;
    SaveDataClass saveData;
    SoundManager sound;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        sound = SoundManager.inst;
        if(this.transform.parent.gameObject.layer != 10 && saveData.isLetterPicked)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.GetComponent<Object>().enabled = false;
            if(this.GetComponent<SpriteRenderer>())
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        uiManager = FindObjectOfType<UI>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public override void ObjectFunction()
    {
        sound.EffectPlay(sound.getItemEffect);
        letterUI.SetActive(true);
        GameObject letter = this.gameObject;
        inventoryMng.PickUp(letter, 0.1f, ItemClass.ItemPrefabOrder.Letter);
        saveData.isLetterPicked = true;
        data.Save();
    }

    public void LetterItem()
    {
        if(letterUI.transform.parent == this.transform)
        {
            letterUI.transform.SetParent(this.transform.parent.parent.parent.parent, false);
        }
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "구겨진 편지";
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            letterUI.SetActive(true);
        }
    }
}
