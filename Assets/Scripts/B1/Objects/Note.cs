using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    UIManager uiManager;
    SlotSelectionMng slotSelectMng;

    void Start()
    {
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public void NoteItem()
    {
        if(slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            uiManager = FindObjectOfType<UIManager>();
            uiManager.noteUI.SetActive(true);
            StartCoroutine(uiManager.LoadTextOneByOne(uiManager.noteText.text, uiManager.inputTextUI));
        }
    }
}
