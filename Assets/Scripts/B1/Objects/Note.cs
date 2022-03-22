using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public GameObject noteUI;
    public Text noteText;
    public Text inputTextUI;
    public GameObject prefabUI;
    UI uiManager;
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void NoteItem()
    {
        if(prefabUI.transform.parent == this.transform)
        {
            prefabUI.transform.SetParent(this.transform.parent.parent.parent.parent, false);
        }
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "책에서 떨어진 편지";
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            uiManager = FindObjectOfType<UI>();
            noteUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(noteText.text, inputTextUI));
        }
    }
}
