using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Muffler : Object
{
    public GameObject mufflerUI;
    public Text mufflerText;
    public Text inputTextUI;
    [SerializeField] GameObject uiObjects;
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
        if(this.transform.parent.gameObject.layer != 10 && saveData.isMufflerPicked)
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
        mufflerUI.SetActive(true);
        uiManager.StartCoroutine(uiManager.LoadTextOneByOne(mufflerText.text, inputTextUI));
        GameObject muffler = this.gameObject;
        inventoryMng.PickUp(muffler, 0.1f, ItemClass.ItemPrefabOrder.Muffler);
        saveData.isMufflerPicked = true;
        data.Save();
    }

    public void MufflerItem()
    {
        if(uiObjects.transform.parent == this.transform)
        {
            uiObjects.transform.SetParent(this.transform.parent.parent.parent.parent, false);
        }
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "찢어진 머플러 조각";
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            mufflerUI.SetActive(true);
            uiManager.StartCoroutine(uiManager.LoadTextOneByOne(mufflerText.text, inputTextUI));
        }
    }
}
